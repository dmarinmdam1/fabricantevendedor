
using System.Threading;

namespace fabricantevendedor
{
    public class Vendedor
    {
        private Almacen almacen;
        private Thread thread;
        private uint periodicidad;
        private uint cantidad;

        public Vendedor(Almacen _almacen, uint _periodicidad, uint _cantidad)
        {
            this.almacen = _almacen;
            this.periodicidad = _periodicidad;
            this.cantidad = _cantidad;
        }

        public void Vende()
        {
            this.thread = new Thread(() => this._Accion());
            this.thread.Start();
        }

        public void Termina()
        {
            thread.Join();
        }

        private void _Accion()
        {
            for (int i = 0 ; i < cantidad ; i++)
            {
                Thread.Sleep((int)periodicidad);
                almacen.Sacar();
            }
        }
    }
}
