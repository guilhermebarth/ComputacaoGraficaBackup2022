using System;
using System.Collections.Generic;
using System.Text;
using CG_Biblioteca;
using gcgcg;
using OpenTK.Graphics.OpenGL;

namespace CG_N2
{
    internal class Slime : ObjetoGeometria
    {
        private Ponto4D ponto1 { get; set; }
        private Ponto4D ponto2 { get; set; }
        private Ponto4D ponto3 { get; set; }
        private Ponto4D ponto4 { get; set; }

        public Slime(string rotulo, Objeto paiRef, Ponto4D ponto1, Ponto4D ponto2, Ponto4D ponto3, Ponto4D ponto4) : base(rotulo, paiRef)
        {
            PrimitivaTipo = PrimitiveType.LineStrip;
            this.ponto1 = ponto1;
            this.ponto2 = ponto2;
            this.ponto3 = ponto3;
            this.ponto4 = ponto4;

            pontosLista.Add(ponto1);
            pontosLista.Add(ponto2);
            pontosLista.Add(ponto3);
            pontosLista.Add(ponto4);
        }

        protected override void DesenharObjeto()
        {
            GL.Begin(PrimitivaTipo);
            foreach (Ponto4D pto in pontosLista)
            {
                GL.Vertex2(pto.X, pto.Y);
            }
            GL.End();
            GL.Begin(PrimitiveType.LineStripAdjacency);
            GL.Vertex2(ponto1.X, ponto1.Y);
            for (float i = 0; i <= 1; i += 0.1f)
            {
                var p0X = ponto1.X + (ponto2.X - ponto1.X) * i;
                var p0Y = ponto1.Y + (ponto2.Y - ponto1.Y) * i;

                var p1X = ponto2.X + (ponto3.X - ponto2.X) * i;
                var p1Y = ponto2.Y + (ponto3.Y - ponto2.Y) * i;

                var p2X = ponto3.X + (ponto4.X - ponto3.X) * i;
                var p2Y = ponto3.Y + (ponto4.Y - ponto3.Y) * i;

                var p01X = p0X + (p1X - p0X) * i;
                var p01Y = p0Y + (p1Y - p0Y) * i;

                var p12X = p1X + (p2X - p1X) * i;
                var p12Y = p1Y + (p2Y - p1Y) * i;

                var resultX = p01X + (p12X - p01X) * i;
                var resultY = p01Y + (p12Y - p01Y) * i;

                GL.Vertex2(resultX, resultY);
            }
            GL.Vertex2(ponto4.X, ponto4.Y);
            GL.End();

        }
    }
}
