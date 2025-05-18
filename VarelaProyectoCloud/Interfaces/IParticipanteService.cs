using VarelaProyectoCloud.Models;


namespace VarelaProyectoCloud.Interfaces
{
    public interface IParticipanteService
    {
        Task<IEnumerable<Participante>> GetAllParticipantesAsync();
        Task<Participante?> GetParticipanteByIdAsync(int id);
        Task<Participante> CreateParticipanteAsync(Participante participante);
        Task<bool> UpdateParticipanteAsync(int id, Participante participante);
        Task<bool> DeleteParticipanteAsync(int id);
    }
}
