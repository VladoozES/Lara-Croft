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
            gL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);


            //Голова Лары по XY
            gL.LoadIdentity();
            gL.Translate(-1.5f, 0.9f, -6.0f);
            gL.Rotate(0.0, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);//*/

            //Голова Лары по YZ
            gL.LoadIdentity();
            gL.Translate(-1.5f, -1.4f, -6.0f);
            gL.Rotate(90, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);//*/

            //Голова Лары вращается
            gL.LoadIdentity();
            gL.Translate(1.0f, 0.0f, -6.0f);
            gL.Rotate(rotateAngle, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);
            


            rotateAngle += 1f;
        }

        private void DrawLaraHair(OpenGL gL)
        {
            throw new NotImplementedException();
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


            //Отрисовка лица
            gL.Color(1f, 1f, 0f);
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
            gL.Begin(OpenGL.GL_TRIANGLES); // Правый маленький треугольник возле виска
                    gL.Vertex(rightCheeckFarPoint[0], rightCheeckFarPoint[1], rightCheeckFarPoint[2]);
                    gL.Vertex(rightTempleAndForehead[0], rightTempleAndForehead[1], rightTempleAndForehead[2]);
                    gL.Vertex(rightForeheadRightHightPoint[0], rightForeheadRightHightPoint[1], rightForeheadRightHightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_TRIANGLES);  // Левый маленький треугольник возле виска
                    gL.Vertex(leftCheeckFarPoint[0], leftCheeckFarPoint[1], leftCheeckFarPoint[2]);
                    gL.Vertex(leftTempleAndForehead[0], leftTempleAndForehead[1], leftTempleAndForehead[2]);
                    gL.Vertex(leftForeheadRightHightPoint[0], leftForeheadRightHightPoint[1], leftForeheadRightHightPoint[2]);
            gL.End();





            ///Точки для волос///
            ///Волосы будут сделаны в 3 "недокольца"///
            ///1-ое кольцо над лбом///
            ///2-ое кольцо - самое большое, проходит через щёчки//
            ///3-ье кольцо - малое дальнее кольцо///
            float[] rightUpperPointOfTriangleAboveForehead = new float[] { -0.175f, 1.45f, 0.35f }; //Верхняя точка треугольника над лбом
            float[] leftUpperPointOfTriangleAboveForehead = new float[] { 0.175f, 1.45f, 0.35f };

            //Точки полигона 2-го (самого большого) кольца. Первая точка - низ правой дальней щеки.
            float[][] secondRing = {
                new float[] { rightFarLowerCheek[0] - 0.2f, rightFarLowerCheek[1], rightFarLowerCheek[2] - 0.2f }, //secondRing[0]
                new float[] { rightCheeckFarPoint[0] - 0.2f, rightCheeckFarPoint[1], rightCheeckFarPoint[2] - 0.2f },   //secondRing[1]
                new float[] { rightCheeckFarPoint[0], rightCheeckFarPoint[1] + 0.5f, rightCheeckFarPoint[2] },  //secondRing[2]
                new float[] { rightUpperPointOfTriangleAboveForehead[0], rightUpperPointOfTriangleAboveForehead[1], rightCheeckFarPoint[2] },   //secondRing[3]
                new float[] { highCenterOfForehead[0], highCenterOfForehead[1], rightCheeckFarPoint[2] },   //secondRing[4]
                new float[] { leftUpperPointOfTriangleAboveForehead[0], leftUpperPointOfTriangleAboveForehead[1], leftCheeckFarPoint[2] },  //secondRing[5]
                new float[] { leftCheeckFarPoint[0], leftCheeckFarPoint[1] + 0.5f, leftCheeckFarPoint[2] }, //secondRing[6]
                new float[] { leftCheeckFarPoint[0] + 0.2f, leftCheeckFarPoint[1], leftCheeckFarPoint[2] - 0.2f },  //secondRing[7]
                new float[] { leftFarLowerCheek[0] + 0.2f, leftFarLowerCheek[1], leftFarLowerCheek[2] - 0.2f }, //secondRing[8]
                new float[] { leftFarLowerCheek[0] + 0.1f, leftFarLowerCheek[1] - 0.5f, leftFarLowerCheek[2] - 0.2f },  //secondRing[9]
                new float[] { rightFarLowerCheek[0] - 0.1f, rightFarLowerCheek[1] - 0.5f, rightFarLowerCheek[2] - 0.2f },   //secondRing[10]
            };

            //Полигон, соединяющий 1-ое кольцо и 2-ое
            float[][] quadStripConnecting1stRingAnd2nd = {
                secondRing[0], rightFarLowerCheek, secondRing[1], rightCheeckFarPoint, secondRing[2], rightForeheadRightHightPoint,
                secondRing[3] , rightUpperPointOfTriangleAboveForehead, secondRing[4], highCenterOfForehead, secondRing[5],
                leftUpperPointOfTriangleAboveForehead, secondRing[6], leftForeheadRightHightPoint, secondRing[7],
                leftCheeckFarPoint, secondRing[8], leftFarLowerCheek
            };

            //Точки полигона 3-го кольца. Это кольцо отталкивается от 2-го кольца
            float[][] thirdRing = {
                new float[] { secondRing[0][0] + 0.2f, secondRing[0][1] - 0.1f, secondRing[0][2] - 0.4f },
                new float[] { secondRing[1][0] + 0.2f, secondRing[1][1] - 0.1f, secondRing[1][2] - 0.4f },
                new float[] { secondRing[2][0] + 0.2f, secondRing[2][1] - 0.1f, secondRing[2][2] - 0.4f },
                new float[] { secondRing[3][0] + 0.05f, secondRing[3][1] - 0.1f, secondRing[3][2] - 0.2f },
                new float[] { secondRing[4][0], secondRing[4][1] - 0.1f, secondRing[4][2] - 0.4f },
                new float[] { secondRing[5][0] - 0.05f, secondRing[5][1] - 0.1f, secondRing[5][2] - 0.2f },
                new float[] { secondRing[6][0] - 0.2f, secondRing[6][1] - 0.1f, secondRing[6][2] - 0.4f },
                new float[] { secondRing[7][0] - 0.2f, secondRing[7][1] - 0.1f, secondRing[7][2] - 0.4f },
                new float[] { secondRing[8][0] - 0.2f, secondRing[8][1] - 0.1f, secondRing[8][2] - 0.4f },
                new float[] { secondRing[9][0] - 0.2f, secondRing[9][1] - 0.1f, secondRing[9][2] - 0.2f },
                new float[] { secondRing[10][0] + 0.2f, secondRing[10][1] - 0.1f, secondRing[10][2] - 0.2f },
            };

            //Полигон, соединяющий 2-ое кольцо и 3-ье
            float[][] quadStripConnecting2ndRingAnd3rd = {
                secondRing[0], thirdRing[0], secondRing[1], thirdRing[1], secondRing[2], thirdRing[2], secondRing[3], thirdRing[3],
                secondRing[4], thirdRing[4], secondRing[5], thirdRing[5], secondRing[6], thirdRing[6], secondRing[7], thirdRing[7],
                secondRing[8], thirdRing[8], secondRing[9], thirdRing[9], secondRing[10], thirdRing[10], secondRing[0], thirdRing[0]
            };



            //Отрисовка волос
            gL.Color(1f, 1f, 1f);
            gL.Begin(OpenGL.GL_TRIANGLES);  //Правый треугольник над лбом
                    gL.Vertex(rightForeheadRightHightPoint[0], rightForeheadRightHightPoint[1], rightForeheadRightHightPoint[2]);
                    gL.Vertex(highCenterOfForehead[0], highCenterOfForehead[1], highCenterOfForehead[2]);
                    gL.Vertex(rightUpperPointOfTriangleAboveForehead[0], rightUpperPointOfTriangleAboveForehead[1], rightUpperPointOfTriangleAboveForehead[2]);
            gL.End();
            gL.Begin(OpenGL.GL_TRIANGLES);  //Левый треугольник над лбом
                    gL.Vertex(leftForeheadRightHightPoint[0], leftForeheadRightHightPoint[1], leftForeheadRightHightPoint[2]);
                    gL.Vertex(highCenterOfForehead[0], highCenterOfForehead[1], highCenterOfForehead[2]);
                    gL.Vertex(leftUpperPointOfTriangleAboveForehead[0], leftUpperPointOfTriangleAboveForehead[1], leftForeheadRightHightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_POLYGON); //Точки полигона 2-го (самого большого) кольца. Первая точка - низ правой дальней щеки.
                    foreach (var vertex in secondRing)
                            gL.Vertex(vertex[0], vertex[1], vertex[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP); //Полигон, соединяющий 1-ое кольцо и 2-ое (Ну почти до конца)
                    foreach (var vertex in quadStripConnecting1stRingAnd2nd)
                        gL.Vertex(vertex[0], vertex[1], vertex[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS); //Квадрат между нижними щёчками и нижней чертой 2-ого кольца волос
                    gL.Vertex(secondRing[9][0], secondRing[9][1], secondRing[9][2]);
                    gL.Vertex(secondRing[10][0], secondRing[10][1], secondRing[10][2]);
                    gL.Vertex(rightFarLowerCheek[0], rightFarLowerCheek[1], rightFarLowerCheek[2]);
                    gL.Vertex(leftFarLowerCheek[0], leftFarLowerCheek[1], leftFarLowerCheek[2]);
            gL.End();
            gL.Begin(OpenGL.GL_TRIANGLES); //Маленький треугольник справа между 1-ым и 2-ым кольцом волос внизу
                    gL.Vertex(secondRing[10][0], secondRing[10][1], secondRing[10][2]);
                    gL.Vertex(secondRing[0][0], secondRing[0][1], secondRing[0][2]);
                    gL.Vertex(rightFarLowerCheek[0], rightFarLowerCheek[1], rightFarLowerCheek[2]);
            gL.End();
            gL.Begin(OpenGL.GL_TRIANGLES); //Маленький треугольник слева между 1-ым и 2-ым кольцом волос внизу
                    gL.Vertex(secondRing[8][0], secondRing[8][1], secondRing[8][2]);
                    gL.Vertex(secondRing[9][0], secondRing[9][1], secondRing[9][2]);
                    gL.Vertex(leftFarLowerCheek[0], leftFarLowerCheek[1], leftFarLowerCheek[2]);
            gL.End();
            gL.Begin(OpenGL.GL_POLYGON); //Точки полигона 3-го кольца
                    foreach (var vertex in thirdRing)
                        gL.Vertex(vertex[0], vertex[1], vertex[2]);
            gL.End(); gL.Begin(OpenGL.GL_QUAD_STRIP); //Полигон, соединяющий 2-ое кольцо и 3-ье
                    foreach (var vertex in quadStripConnecting2ndRingAnd3rd)
                        gL.Vertex(vertex[0], vertex[1], vertex[2]);
            gL.End();
        }
    }
}
