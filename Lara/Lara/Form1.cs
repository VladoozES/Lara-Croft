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

            

            //Лицо Лары по XY
            gL.LoadIdentity();
            gL.Translate(-1.5f, 1.0f, -6.0f);
            gL.Rotate(0.0, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);//*/

            //Лицо Лары по YZ
            gL.LoadIdentity();
            gL.Translate(-1.5f, -1.0f, -6.0f);
            gL.Rotate(90, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);//*/

            //Лицо Лары вращается
            gL.LoadIdentity();
            gL.Translate(1.0f, 0.0f, -6.0f);
            gL.Rotate(rotateAngle, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);






            rotateAngle += 3f;
        }

        private void DrawLaraFace(OpenGL gL)
        {
            ///Общие точки///
            float[] rightCheeckFarPoint = new float[] { -0.6f, 0.7f, 0.0f };    //Дальняя верхняя точка щеки
            float[] leftCheeckFarPoint = new float[] { 0.6f, 0.7f, 0.0f };

            float[] rightCheeckNearPoint = new float[] { -0.4f, 0.4f, 0.4f };   //Ближняя верхняя точка щеки
            float[] leftCheeckNearPoint = new float[] { 0.4f, 0.4f, 0.4f };

            float[] rightFarLowerCheek = new float[] { -0.4f, -0.05f, 0.0f }; //Дальняя нижняя точка щеки
            float[] leftFarLowerCheek = new float[] { 0.4f, -0.05f, 0.0f };

            float[] rightTempleAndForehead = new float[] { -0.4f, 1f, 0.4f };   //Висок примерно
            float[] leftTempleAndForehead = new float[] { 0.4f, 1f, 0.4f };

            float[] rightForeheadRightHightPoint = new float[] { -0.35f, 1.2f, 0.35f }; //Дальняя верхняя точка лба
            float[] leftForeheadRightHightPoint = new float[] { 0.35f, 1.2f, 0.35f };

            float[] rightChin = new float[] { -0.2f, -0.4f, 0.55f }; //Подбородок
            float[] leftChin = new float[] { 0.2f, -0.4f, 0.55f };

            float[] lowerCenterOfForehead = new float[] { 0.0f, 1f, 0.8f }; //Нижний центр лба
            float[] highCenterOfForehead = new float[] { 0.0f, 1.2f, 0.6f };    //Верхний центр лба
            float[] faceCenter = new float[] { 0.0f, 0.4f, 0.85f }; //Самый центр лица
            float[] faceLowerPoint = new float[] { 0.0f, -0.4f, 0.8f }; //Низ центра лица



            ///Точки для волос///
            //float[] 




            gL.Begin(OpenGL.GL_QUADS);  // Деталь 1
                    gL.Vertex(rightCheeckFarPoint[0], rightCheeckFarPoint[1], rightCheeckFarPoint[2]);
                    gL.Vertex(rightFarLowerCheek[0], rightFarLowerCheek[1], rightFarLowerCheek[2]);
                    gL.Vertex(rightChin[0], rightChin[1], rightChin[2]);
                    gL.Vertex(rightCheeckNearPoint[0], rightCheeckNearPoint[1], rightCheeckNearPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS);  // Зеркало деталь 1
                    gL.Vertex(leftCheeckFarPoint[0], leftCheeckFarPoint[1], leftCheeckFarPoint[2]);
                    gL.Vertex(leftFarLowerCheek[0], leftFarLowerCheek[1], leftFarLowerCheek[2]);
                    gL.Vertex(leftChin[0], leftChin[1], leftChin[2]);
                    gL.Vertex(leftCheeckNearPoint[0], leftCheeckNearPoint[1], leftCheeckNearPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_TRIANGLES); // Деталь 2
                    gL.Vertex(rightCheeckFarPoint[0], rightCheeckFarPoint[1], rightCheeckFarPoint[2]);
                    gL.Vertex(rightCheeckNearPoint[0], rightCheeckNearPoint[1], rightCheeckNearPoint[2]);
                    gL.Vertex(rightTempleAndForehead[0], rightTempleAndForehead[1], rightTempleAndForehead[2]);
            gL.End();
            gL.Begin(OpenGL.GL_TRIANGLES); // Зеркало деталь 2
                    gL.Vertex(leftCheeckFarPoint[0], leftCheeckFarPoint[1], leftCheeckFarPoint[2]);
                    gL.Vertex(leftCheeckNearPoint[0], leftCheeckNearPoint[1], leftCheeckNearPoint[2]);
                    gL.Vertex(leftTempleAndForehead[0], leftTempleAndForehead[1], leftTempleAndForehead[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP); // Деталь 3
                    gL.Vertex(rightTempleAndForehead[0], rightTempleAndForehead[1], rightTempleAndForehead[2]);
                    gL.Vertex(lowerCenterOfForehead[0], lowerCenterOfForehead[1], lowerCenterOfForehead[2]);
                    gL.Vertex(rightCheeckNearPoint[0], rightCheeckNearPoint[1], rightCheeckNearPoint[2]);
                    gL.Vertex(faceCenter[0], faceCenter[1], faceCenter[2]);
                    gL.Vertex(rightChin[0], rightChin[1], rightChin[2]);
                    gL.Vertex(faceLowerPoint[0], faceLowerPoint[1], faceLowerPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP); // Зеркало деталь 3
                    gL.Vertex(leftTempleAndForehead[0], leftTempleAndForehead[1], leftTempleAndForehead[2]);
                    gL.Vertex(lowerCenterOfForehead[0], lowerCenterOfForehead[1], lowerCenterOfForehead[2]);
                    gL.Vertex(leftCheeckNearPoint[0], leftCheeckNearPoint[1], leftCheeckNearPoint[2]);
                    gL.Vertex(faceCenter[0], faceCenter[1], faceCenter[2]);
                    gL.Vertex(leftChin[0], leftChin[1], leftChin[2]);
                    gL.Vertex(faceLowerPoint[0], faceLowerPoint[1], faceLowerPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS); // Деталь 4
                    gL.Vertex(rightTempleAndForehead[0], rightTempleAndForehead[1], rightTempleAndForehead[2]);
                    gL.Vertex(lowerCenterOfForehead[0], lowerCenterOfForehead[1], lowerCenterOfForehead[2]);
                    gL.Vertex(highCenterOfForehead[0], highCenterOfForehead[1], highCenterOfForehead[2]);
                    gL.Vertex(rightForeheadRightHightPoint[0], rightForeheadRightHightPoint[1], rightForeheadRightHightPoint[2]);
            gL.End(); gL.Begin(OpenGL.GL_QUADS); // Зеркало деталь 4
                    gL.Vertex(leftTempleAndForehead[0], leftTempleAndForehead[1], leftTempleAndForehead[2]);
                    gL.Vertex(lowerCenterOfForehead[0], lowerCenterOfForehead[1], lowerCenterOfForehead[2]);
                    gL.Vertex(highCenterOfForehead[0], highCenterOfForehead[1], highCenterOfForehead[2]);
                    gL.Vertex(leftForeheadRightHightPoint[0], leftForeheadRightHightPoint[1], leftForeheadRightHightPoint[2]);
            gL.End();
        }
    }
}
