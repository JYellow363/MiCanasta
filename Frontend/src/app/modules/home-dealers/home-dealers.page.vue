<template>
  <div class="dealers-container">
    <div class="dealers-container__members-quantity">
      <img src="../../../assets/ic_members.svg" alt="members" />
      <p color-rojo>{{ numIntegrantes }}/{{tienda.limite}}</p>
    </div>
    <div class="dealers-container__title">
      <h2>Lista de distribuidores</h2>
    </div>

    <div class="dealers-container__add">
      <button v-on:click="agregarSeller">
        <img src="../../../assets/ic_plus.svg" alt="plus" />
      </button>

    <ErrorModalShared
      @Event="closeModal"
      v-if="isShowModalError"
      :title="error.title"
      :description="error.description"
    />

      <div class="input-shared-container">
        <input
          class="input-shared-component"
          type="text"
          v-model="dni" 
          placeholder="Ingrese un DNI"
          maxlength="8"
        />

      <div class="dealers-container__list-members">
      <members-card-shared
        :person="user"
        :dni="user.dni"
        :userIsAdmin="userIsAdmin"
        :numIntegrantes = "numIntegrantes"
        :unicoAdmin = "unicoAdmin"
        v-for="(user, i) in miembros"
        v-bind:key="i"
      />
    </div>
      </div>
    </div>
  </div>
</template>

<script>
import MembersCardShared from "../../shared/members/sellers.component.vue";
import UsuarioService from "../../core/services/usuario.service";
import TiendaService from "../../core/services/tienda.service";
import ValidacionService from "../../core/services/validacion.service";
import { TiendaGet } from '../../core/model/tienda.model';
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";

export default {
  name: "HomeDealersPage",
  components: { MembersCardShared, ErrorModalShared },

  data: function() {
    return {   
      idTienda: -1,
      miembros: [ ],
      roles: [],
      userIsAdmin: false,
      numIntegrantes: 0,
      unicoAdmin: false,
      rolx: false,
      dni: "",
      tienda: TiendaGet,
      isShowModalError: false,
      error: { title: "¡Error!" },
    };
  },

  created() {
    this.getRolUsuario();
    this.$data.idTienda = this.$route.params.id;
    this.listarMiembros();
    this.GetLimiteTienda();
  },

methods: {

  async GetLimiteTienda(){
    const res = await TiendaService.GetLimiteTienda(this.idTienda);
    this.tienda = res.data;
  },

  async agregarSeller(){
    try{
        if (this.numIntegrantes < this.tienda.limite) {
        const res = await TiendaService.agregarSeller(this.$data.idTienda,
        this.$data.dni);
        this.$router.go();
        console.log(res); 
        } else if (!ValidacionService.validarDni(this.dni)){
        this.isShowModalError = true;
        this.error.description = "El DNI ingresado no es válido";
        this.cerrarModalConfirmacion();
        } else {
        this.isShowModalError = true;
        this.error.description = "Se excedió el máximo de distribuidores de esta tienda";
        this.cerrarModalConfirmacion();
        }
     } catch (error) {
      console.log(error);
    }
  },

    async isUnicoAdmin(){
      let cont = 0;
      for(let i = 0; i < this.numIntegrantes; i++){
          if(await this.isAdmin(this.miembros[i].dni) == true) cont++;
      }
      if(this.userIsAdmin == true && cont == 1) this.unicoAdmin = true;
    },

    async isAdmin(dniIntegrante){
      let cont = 0;
      let rolesAux;
      try {
        const res = await UsuarioService.getUsuario(dniIntegrante);
        rolesAux = res.data.rolUsuarios;
        for(let i = 0; i < rolesAux.length; i++){
          if(rolesAux[i].rolPerfilId == 3) cont++;
        }
        if(cont > 0) return true;
        else return false;
      }
      catch (error) {
        console.log(error);        
      }
    },

    async listarTienda() {
      try {
        const result = await TiendaService.listarTienda(this.$data.idTienda);
        this.$data.idTienda = result.data.idTienda;
        this.listarMiembros();
      } catch (error) {
        console.log(error);
      }
    },

    async listarMiembros() {
        try {
        const result = await TiendaService.getUsuariosByTiendaId(
          this.$data.idTienda
        );
        this.$data.miembros  = result.data;
        this.numIntegrantes = this.$data.miembros.length;
        this.isUnicoAdmin();
      } catch (error) {
        console.log(error);
      }
    },

    async getRolUsuario(){
       try {
        const res = await UsuarioService.getUsuario(localStorage.getItem("dni"));
        this.roles = res.data.rolUsuarios;
        for(let i=0; i < this.roles.length; i++){
          if(this.roles[i].rolPerfilId == 3) {
            this.userIsAdmin=true;
            this.rolx = true;
          } else {
            this.rolx = false;
          }
        }        
      }
      catch (error) {
        console.log(error);        
      }
    },
    cerrarModalConfirmacion() {
      this.errorFlagModal = false;
    },

    closeModal() {
      this.$data.isShowModalError = false;
    },
  },

};
</script>

<style>
.dealers-container{
    padding: 0 32px;
    height: calc(640px  - 128px);
    overflow: auto;
}

.dealers-container__members-quantity{
    display: flex;
    align-items: center;
    margin-top: 32px;
}
.dealers-container__members-quantity p {
    font-size: 18px;
    font-weight: 600;
    margin: 0 0 0 6px;
}
.dealers-container__title{
    margin-top: 24px;
}
.dealers-container__title h2{
    font-weight: 600;
    color: #000;
    margin: 0;
}

.dealers-container__add{
    margin-top: 32px;
    display: flex;
    justify-content: center;
    flex-direction: column;
}
.dealers-container__add button{
    margin: 0 auto;
    width: 40px;
    height: 40px;
    display: flex;
    justify-content: center;
    align-items: center;
    border: none;
    cursor: pointer;
    border-radius: 4px;
    background: #F76A8C;
}

.dealers-container__add > div{
    margin-top: 32px;
}

.dealers-container__add input{
    text-align: center;
}

</style>
