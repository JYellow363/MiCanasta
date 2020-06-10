﻿using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface SolicitudService
    {
        public List<SolicitudDto> GetAll();
        SolicitudDto GetById(string dni, string familiaNombre);
        public SolicitudDto Create(SolicitudCreateDto model);
        bool AceptaSolicitudes(SolicitudCreateDto model);
        SolicitudBusquedaDto ObtenerNombreFamilia(String FamiliaId);
        bool BorrarSolicitud(SolicitudUsuarioDto solicitud);

    }

}