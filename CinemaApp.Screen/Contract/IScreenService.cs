namespace CinemaApp.Screen.Contract
{
    public interface IScreenService
    { 

        Task<IEnumerable<CinemaApp.Models.Models.Screen>> GetScreenList();
        Task<CinemaApp.Models.Models.Screen> GeScreenById(int id);
        Task<CinemaApp.Models.Models.Screen> CreateScreen(CinemaApp.Models.Models.Screen screen);
        Task<int> UpdateScreen(CinemaApp.Models.Models.Screen screen);
        Task<int> DeleteScreen(CinemaApp.Models.Models.Screen screen);
    }
}
