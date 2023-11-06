using Microsoft.AspNetCore.Components.Web;

namespace IT_Installation.FrontEnd.Services.Interface
{
    public interface IMouseService
    {
        event EventHandler<MouseEventArgs>? OnMove;
        event EventHandler<MouseEventArgs>? OnUp;
        event EventHandler<MouseEventArgs>? OnLeave;

        void FireLeave(object obj, MouseEventArgs evt);
        void FireMove(object obj, MouseEventArgs evt);
        void FireUp(object obj, MouseEventArgs evt);
    }
}
