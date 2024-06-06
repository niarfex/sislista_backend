﻿using Application.Input;
using AutoMapper;
using Domain.Exceptions;
using Infra.MarcoLista.Input.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Infra.MarcoLista.Input.Controllers
{
    [Route("/v1/marco-lista")]
    [ApiController]
    public class MarcoListaController : ControllerBase
    {
    }
}