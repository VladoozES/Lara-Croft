using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace Lara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float rotateAngle = 0f;

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gL = openGLControl1.OpenGL;
            gL.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
            gL.Color(1f, 1f, 1f);
            gL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            ///Общие точки///
            float[] rightCheeckFarPoint = new float[] { -1.0f, 0.7f, 0.0f };
            float[] rightCheeckNearPoint = new float[] { -0.8f, 0.6f, 0.5f };
            float[] rightTempleAndForehead = new float[] { -0.8f, 1f, 0.4f };
            float[] lowerCenterOfForehead = new float[] { -0.4f, 1f, 0.6f};
            float[] faceCenter = new float[] { -0.4f, 0.6f, 0.6f};

            //Лицо Лары
            gL.LoadIdentity();
            gL.Translate(0.0f, 0.0f, -6.0f);
            gL.Rotate(rotateAngle, 0.0f, 1.0f, 0.0f);
            gL.Begin(OpenGL.GL_QUADS);  // Деталь 1
                    gL.Vertex(rightCheeckFarPoint[0], rightCheeckFarPoint[1], rightCheeckFarPoint[2]);
                    gL.Vertex(-1.0f, 0.0f, 0.0f);
                    gL.Vertex(-0.8f, -0.4f, 0.5f);
                    gL.Vertex(rightCheeckNearPoint[0], rightCheeckNearPoint[1], rightCheeckNearPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_TRIANGLES); // Деталь 2
                    gL.Vertex(rightCheeckFarPoint[0], rightCheeckFarPoint[1], rightCheeckFarPoint[2]);
                    gL.Vertex(rightCheeckNearPoint[0], rightCheeckNearPoint[1], rightCheeckNearPoint[2]);
                    gL.Vertex(rightTempleAndForehead[0], rightTempleAndForehead[1], rightTempleAndForehead[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP); // Деталь 3
                    gL.Vertex(rightTempleAndForehead[0], rightTempleAndForehead[1], rightTempleAndForehead[2]);
                    gL.Vertex(lowerCenterOfForehead[0], lowerCenterOfForehead[1], lowerCenterOfForehead[2]);
                    gL.Vertex(rightCheeckNearPoint[0], rightCheeckNearPoint[1], rightCheeckNearPoint[2]);
                    gL.Vertex(faceCenter[0], faceCenter[1], faceCenter[2]);
                    gL.Vertex(-0.8f, -0.4f, 0.5f);
                    gL.Vertex(-0.4f, -0.4f, 0.6f);
            gL.End();



            rotateAngle += 3f;
        }
    }
}
