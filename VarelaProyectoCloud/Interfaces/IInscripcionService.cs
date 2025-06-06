﻿using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Services;

namespace VarelaProyectoCloud.Interfaces
{
    public interface IInscripcionService
    {
        Task<IEnumerable<Inscripcion>> GetAllInscripcionesAsync();
        Task<Inscripcion?> GetInscripcionByIdAsync(int id);
        Task<Inscripcion> CreateInscripcionAsync(Inscripcion inscripcion);
        Task<Inscripcion> UpdateInscripcionAsync(int id, Inscripcion inscripcion);
        Task<bool> DeleteInscripcionAsync(int id);
        Task<bool> CancelarInscripcionAsync(int id);
        Task<string> RegistrarPagoAsync(Pago nuevoPago);
        Task<string> CrearCertificadoAsync(int inscripcionId);

    }
}
