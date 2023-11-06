using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace IT_Installation.FrontEnd.Components
{
    public partial class Draggable
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        double? x;
        [Parameter]
        public double X
        {
            get
            {
                return this.x ?? 0;
            }

            set
            {
                if (!this.x.HasValue || !this.isDown & this.XChanged.HasDelegate)
                {
                    this.x = value;
                }
            }
        }

        [Parameter]
        public EventCallback<double> XChanged { get; set; }

        double? y;
        [Parameter]
        public double Y
        {
            get
            {
                return this.y ?? 0;
            }

            set
            {
                if (!this.y.HasValue || !this.isDown & this.YChanged.HasDelegate)
                {
                    this.y = value;
                }
            }
        }

        [Parameter]
        public EventCallback<double> YChanged { get; set; }

        protected override void OnInitialized()
        {
            this.mouseSrv.OnMove += this.OnMove;
            this.mouseSrv.OnUp += this.OnUpLeave;
            this.mouseSrv.OnLeave += this.OnUpLeave;
            base.OnInitialized();
        }

        string cursor = "grab";
        bool _isDown;
        bool isDown
        {
            get
            {
                return this._isDown;
            }

            set
            {
                this._isDown = value;
                this.cursor = this._isDown ? "grabbing" : "grab";
            }
        }

        double cursorX;
        double cursorY;
        void OnDown(MouseEventArgs e)
        {
            this.isDown = true;
            this.cursorX = e.ClientX;
            this.cursorY = e.ClientY;
        }

        void OnUpLeave(object? _, MouseEventArgs e) => this.isDown = false;
        void OnMove(object? _, MouseEventArgs e)
        {
            if (!this.isDown)
                return;
            this.x = this.x - (this.cursorX - e.ClientX);
            this.y = this.y - (this.cursorY - e.ClientY);
            this.cursorX = e.ClientX;
            this.cursorY = e.ClientY;
            this.XChanged.InvokeAsync(this.x.Value);
            this.YChanged.InvokeAsync(this.y.Value);
        }

        public void Dispose()
        {
            this.mouseSrv.OnMove -= this.OnMove;
            this.mouseSrv.OnUp -= this.OnUpLeave;
            this.mouseSrv.OnLeave -= this.OnUpLeave;
        }
    }
}