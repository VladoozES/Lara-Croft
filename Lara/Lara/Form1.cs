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
        float[] positionOfLaraByXY = new float[] { -2.5f, 5f, -15.0f };
        float[] positionOfRotatingLara = new float[] { 2.5f, 5f, -15.0f };

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gL = openGLControl1.OpenGL;
            gL.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
            gL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);


            //Голова Лары по XY
            gL.LoadIdentity();
            gL.Translate(positionOfLaraByXY[0], positionOfLaraByXY[1], positionOfLaraByXY[2]);
            gL.Rotate(0.0, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);//*/

            //Голова Лары по YZ
            /*gL.LoadIdentity();
            gL.Translate(-1.5f, -1.4f, -6.0f);
            gL.Rotate(90, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);//*/

            //Голова Лары вращается
            gL.LoadIdentity();
            gL.Translate(positionOfRotatingLara[0], positionOfRotatingLara[1], positionOfRotatingLara[2]);
            gL.Rotate(rotateAngle, 0.0f, 1.0f, 0.0f);
            DrawLaraFace(gL);//*/

            //Шея и торс Лары по XY
            gL.LoadIdentity();
            gL.Translate(positionOfLaraByXY[0], positionOfLaraByXY[1], positionOfLaraByXY[2]);
            gL.Rotate(0.0, 0.0f, 1.0f, 0.0f);
            DrawLaraNeckAndTorso(gL);//*/

            //Шея и торс Лары вращаются
            gL.LoadIdentity();
            gL.Translate(positionOfRotatingLara[0], positionOfRotatingLara[1], positionOfRotatingLara[2]);
            gL.Rotate(rotateAngle, 0.0f, 1.0f, 0.0f);
            DrawLaraNeckAndTorso(gL);//*/

            //Низ Лары по XY
            gL.LoadIdentity();
            gL.Translate(positionOfLaraByXY[0], positionOfLaraByXY[1], positionOfLaraByXY[2]);
            gL.Rotate(0.0, 0.0f, 1.0f, 0.0f);
            DrawLaraBottom(gL);//*/

            //Низ Лары вращается
            gL.LoadIdentity();
            gL.Translate(positionOfRotatingLara[0], positionOfRotatingLara[1], positionOfRotatingLara[2]);
            gL.Rotate(rotateAngle, 0.0f, 1.0f, 0.0f);
            DrawLaraBottom(gL);//*/


            rotateAngle += 1f;
        }

        private void DrawLaraBottom(OpenGL gL)
        {
            gL.Color(0.31f, 0.78f, 0.47f);
            DrawHemisphereByZ(10, 5, 0.65f, gL, -0.3f, -4f, -0.2f);  //1-ая ягодица
            DrawHemisphereByZ(10, 5, 0.65f, gL, 0.3f, -4f, -0.2f);   //2-ая ягодица

            ///Передняя сторона шорт
            float[] nearRightTopOfPelvis = new float[] { -0.85f, -3.4f, 0.3f }; //Ближняя точка правой стороны верхнего таза
            float[] nearLeftTopOfPelvis = new float[] { 0.85f, -3.4f, 0.3f };   //Ближняя точка левой стороны верхнего таза
            float[] shortsRightBottomRightPoint = new float[] { -1f, -5f, 0.35f }; //Правая шорта, правая точка
            float[] shortsRightBottomLeftPoint = new float[] { -0.2f, -5f, 0.35f };   //Правая шорта, левая точка
            float[] rightNotchBetweenLegs = new float[] { -0.15f, -4.5f, 0.3f };   //Междуножье, правая точка
            float[] leftNotchBetweenLegs = new float[] { 0.15f, -4.5f, 0.3f };     //Междуножье, левая точка
            float[] shortsLeftBottomLeftPoint = new float[] { 1f, -5f, 0.35f };    //Левая шорта,  левая точка
            float[] shortsLeftBottomRightPoint = new float[] { 0.2f, -5f, 0.35f };    //Левая шорта, правая точка

            ///Задняя сторона шорт
            float[] farRightTopOfPelvis = new float[] { -0.85f, -3.4f, -0.5f }; //Ближняя точка правой стороны верхнего таза
            float[] farLeftTopOfPelvis = new float[] { 0.85f, -3.4f, -0.5f };   //Ближняя точка левой стороны верхнего таза
            float[] shortsAssRightBottomRightPoint = new float[] { -1f, -5f, -0.5f }; //Правая шорта, правая точка
            float[] shortsAssRightBottomLeftPoint = new float[] { -0.2f, -5f, -0.5f };   //Правая шорта, левая точка
            float[] rightAssNotchBetweenLegs = new float[] { -0.15f, -4.5f, -0.4f };   //Междуножье, правая точка
            float[] leftAssNotchBetweenLegs = new float[] { 0.15f, -4.5f, -0.4f };     //Междуножье, левая точка
            float[] shortsAssLeftBottomLeftPoint = new float[] { 1f, -5f, -0.5f };    //Левая шорта,  левая точка
            float[] shortsAssLeftBottomRightPoint = new float[] { 0.2f, -5f, -0.5f };    //Левая шорта, правая точка

            ///Отрисовка передней стороны шорт
            gL.Begin(OpenGL.GL_POLYGON);
                    gL.Vertex(nearRightTopOfPelvis[0], nearRightTopOfPelvis[1], nearRightTopOfPelvis[2]);
                    gL.Vertex(nearLeftTopOfPelvis[0], nearLeftTopOfPelvis[1], nearLeftTopOfPelvis[2]);
                    gL.Vertex(shortsLeftBottomLeftPoint[0], shortsLeftBottomLeftPoint[1], shortsLeftBottomLeftPoint[2]);
                    gL.Vertex(shortsLeftBottomRightPoint[0], shortsLeftBottomRightPoint[1], shortsLeftBottomRightPoint[2]);
                    gL.Vertex(leftNotchBetweenLegs[0], leftNotchBetweenLegs[1], leftNotchBetweenLegs[2]);
                    gL.Vertex(rightNotchBetweenLegs[0], rightNotchBetweenLegs[1], rightNotchBetweenLegs[2]);
                    gL.Vertex(shortsRightBottomLeftPoint[0], shortsRightBottomLeftPoint[1], shortsRightBottomLeftPoint[2]);
                    gL.Vertex(shortsRightBottomRightPoint[0], shortsRightBottomRightPoint[1], shortsRightBottomRightPoint[2]);
                    gL.Vertex(nearRightTopOfPelvis[0], nearRightTopOfPelvis[1], nearRightTopOfPelvis[2]);
            gL.End();

            ///Отрисовка задней стороны шорт
            gL.Begin(OpenGL.GL_POLYGON);
                    gL.Vertex(farRightTopOfPelvis[0], farRightTopOfPelvis[1], farRightTopOfPelvis[2]);
                    gL.Vertex(farLeftTopOfPelvis[0], farLeftTopOfPelvis[1], farLeftTopOfPelvis[2]);
                    gL.Vertex(shortsAssLeftBottomLeftPoint[0], shortsAssLeftBottomLeftPoint[1], shortsAssLeftBottomLeftPoint[2]);
                    gL.Vertex(shortsAssLeftBottomRightPoint[0], shortsAssLeftBottomRightPoint[1], shortsAssLeftBottomRightPoint[2]);
                    gL.Vertex(leftAssNotchBetweenLegs[0], leftAssNotchBetweenLegs[1], leftAssNotchBetweenLegs[2]);
                    gL.Vertex(rightAssNotchBetweenLegs[0], rightAssNotchBetweenLegs[1], rightAssNotchBetweenLegs[2]);
                    gL.Vertex(shortsAssRightBottomLeftPoint[0], shortsAssRightBottomLeftPoint[1], shortsAssRightBottomLeftPoint[2]);
                    gL.Vertex(shortsAssRightBottomRightPoint[0], shortsAssRightBottomRightPoint[1], shortsAssRightBottomRightPoint[2]);
                    gL.Vertex(farRightTopOfPelvis[0], farRightTopOfPelvis[1], farRightTopOfPelvis[2]);
            gL.End();

            ///Соединение задних и передних частей шорт
            gL.Begin(OpenGL.GL_QUAD_STRIP);
                    gL.Vertex(farRightTopOfPelvis[0], farRightTopOfPelvis[1], farRightTopOfPelvis[2]);
                    gL.Vertex(nearRightTopOfPelvis[0], nearRightTopOfPelvis[1], nearRightTopOfPelvis[2]);
                    gL.Vertex(shortsAssRightBottomRightPoint[0], shortsAssRightBottomRightPoint[1], shortsAssRightBottomRightPoint[2]);
                    gL.Vertex(shortsRightBottomRightPoint[0], shortsRightBottomRightPoint[1], shortsRightBottomRightPoint[2]);
                    gL.Vertex(shortsAssRightBottomLeftPoint[0], shortsAssRightBottomLeftPoint[1], shortsAssRightBottomLeftPoint[2]);
                    gL.Vertex(shortsRightBottomLeftPoint[0], shortsRightBottomLeftPoint[1], shortsRightBottomLeftPoint[2]);
                    gL.Vertex(rightAssNotchBetweenLegs[0], rightAssNotchBetweenLegs[1], rightAssNotchBetweenLegs[2]);
                    gL.Vertex(rightNotchBetweenLegs[0], rightNotchBetweenLegs[1], rightNotchBetweenLegs[2]);
                    gL.Vertex(leftAssNotchBetweenLegs[0], leftAssNotchBetweenLegs[1], leftAssNotchBetweenLegs[2]);
                    gL.Vertex(leftNotchBetweenLegs[0], leftNotchBetweenLegs[1], leftNotchBetweenLegs[2]);
                    gL.Vertex(shortsAssLeftBottomRightPoint[0], shortsAssLeftBottomRightPoint[1], shortsAssLeftBottomRightPoint[2]);
                    gL.Vertex(shortsLeftBottomRightPoint[0], shortsLeftBottomRightPoint[1], shortsLeftBottomRightPoint[2]);
                    gL.Vertex(shortsAssLeftBottomLeftPoint[0], shortsAssLeftBottomLeftPoint[1], shortsAssLeftBottomLeftPoint[2]);
                    gL.Vertex(shortsLeftBottomLeftPoint[0], shortsLeftBottomLeftPoint[1], shortsLeftBottomLeftPoint[2]);
                    gL.Vertex(farLeftTopOfPelvis[0], farLeftTopOfPelvis[1], farLeftTopOfPelvis[2]);
                    gL.Vertex(nearLeftTopOfPelvis[0], nearLeftTopOfPelvis[1], nearLeftTopOfPelvis[2]);
            gL.End();



            ///////////////////
            ///Отрисовка ног///
            ///////////////////
            ///////////////////
            ///////////////////
            ///Правое бедро////
            float[] rightKneeFrontRight = new float[] { -0.7f, -7f, 0.3f };
            float[] rightKneeBackRight = new float[] { -0.7f, -7f, -0.1f };
            float[] rightKneeFrontLeft = new float[] { -0.35f, -7f, 0.3f };
            float[] rightKneeBackLeft = new float[] { -0.35f, -7f, -0.1f };
            ///////////////////
            gL.Color(1f, 1f, 0f);
            gL.Begin(OpenGL.GL_QUAD_STRIP);
                    gL.Vertex(shortsRightBottomRightPoint[0] + 0.01f, shortsRightBottomRightPoint[1], shortsRightBottomRightPoint[2] - 0.01f);
                    gL.Vertex(rightKneeFrontRight[0], rightKneeFrontRight[1], rightKneeFrontRight[2]);
                    gL.Vertex(shortsAssRightBottomRightPoint[0] + 0.01f, shortsAssRightBottomRightPoint[1], shortsAssRightBottomRightPoint[2] + 0.01f);
                    gL.Vertex(rightKneeBackRight[0], rightKneeBackRight[1], rightKneeBackRight[2]);
                    gL.Vertex(shortsAssRightBottomLeftPoint[0] + 0.01f, shortsAssRightBottomLeftPoint[1], shortsAssRightBottomLeftPoint[2] + 0.01f);
                    gL.Vertex(rightKneeBackLeft[0], rightKneeBackLeft[1], rightKneeBackLeft[2]);
                    gL.Vertex(shortsRightBottomLeftPoint[0] + 0.01f, shortsRightBottomLeftPoint[1], shortsRightBottomLeftPoint[2] + 0.01f);
                    gL.Vertex(rightKneeFrontLeft[0], rightKneeFrontLeft[1], rightKneeFrontLeft[2]);
                    gL.Vertex(shortsRightBottomRightPoint[0] + 0.01f, shortsRightBottomRightPoint[1], shortsRightBottomRightPoint[2] - 0.01f);
                    gL.Vertex(rightKneeFrontRight[0], rightKneeFrontRight[1], rightKneeFrontRight[2]);
            gL.End();
            ///////////////////
            ///////////////////
            ///Левое бедро/////
            float[] leftKneeFrontLeft = new float[] { 0.7f, -7f, 0.3f };
            float[] leftKneeBackLeft = new float[] { 0.7f, -7f, -0.1f };
            float[] leftKneeFrontRight = new float[] { 0.35f, -7f, 0.3f };
            float[] leftKneeBackRight = new float[] { 0.35f, -7f, -0.1f };
            ///////////////////
            gL.Color(1f, 1f, 0f);
            gL.Begin(OpenGL.GL_QUAD_STRIP);
                    gL.Vertex(shortsLeftBottomLeftPoint[0] - 0.01f, shortsLeftBottomLeftPoint[1], shortsLeftBottomLeftPoint[2] - 0.01f);
                    gL.Vertex(leftKneeFrontLeft[0], leftKneeFrontLeft[1], leftKneeFrontLeft[2]);
                    gL.Vertex(shortsAssLeftBottomLeftPoint[0] - 0.01f, shortsAssLeftBottomLeftPoint[1], shortsAssLeftBottomLeftPoint[2] + 0.01f);
                    gL.Vertex(leftKneeBackLeft[0], leftKneeBackLeft[1], leftKneeBackLeft[2]);
                    gL.Vertex(shortsAssLeftBottomRightPoint[0] + 0.01f, shortsAssLeftBottomRightPoint[1], shortsAssLeftBottomRightPoint[2] + 0.01f);
                    gL.Vertex(leftKneeBackRight[0], leftKneeBackRight[1], leftKneeBackRight[2]);
                    gL.Vertex(shortsLeftBottomRightPoint[0] + 0.01f, shortsRightBottomLeftPoint[1], shortsRightBottomLeftPoint[2] + 0.01f);
                    gL.Vertex(leftKneeFrontRight[0], leftKneeFrontRight[1], leftKneeFrontRight[2]);
                    gL.Vertex(shortsLeftBottomLeftPoint[0] - 0.01f, shortsLeftBottomLeftPoint[1], shortsLeftBottomLeftPoint[2] - 0.01f);
                    gL.Vertex(leftKneeFrontLeft[0], leftKneeFrontLeft[1], leftKneeFrontLeft[2]);
            gL.End();
            ///////////////////
            ///////////////////
            ///Правая голень///
            float[] rightShinFrontRight = new float[] { -0.85f, -7.8f, 0.35f };
            float[] rightShinBackRight = new float[] { -0.95f, -7.8f, -0.2f };
            float[] rightShinFrontLeft = new float[] { -0.28f, -7.8f, 0.35f };
            float[] rightShinBackLeft = new float[] { -0.23f, -7.8f, -0.2f };
            ///////////////////
            gL.Color(1f, 1f, 0f);
            gL.Begin(OpenGL.GL_QUAD_STRIP);
            gL.Vertex(rightKneeFrontRight[0], rightKneeFrontRight[1], rightKneeFrontRight[2]);
            gL.Vertex(rightShinFrontRight[0], rightShinFrontRight[1], rightShinFrontRight[2]);
            gL.Vertex(rightKneeBackRight[0], rightKneeBackRight[1], rightKneeBackRight[2]);
            gL.Vertex(rightShinBackRight[0], rightShinBackRight[1], rightShinBackRight[2]);
            gL.Vertex(rightKneeBackLeft[0], rightKneeBackLeft[1], rightKneeBackLeft[2]);
            gL.Vertex(rightShinBackLeft[0], rightShinBackLeft[1], rightShinBackLeft[2]);
            gL.Vertex(rightKneeFrontLeft[0], rightKneeFrontLeft[1], rightKneeFrontLeft[2]);
            gL.Vertex(rightShinFrontLeft[0], rightShinFrontLeft[1], rightShinFrontLeft[2]);
            gL.Vertex(rightKneeFrontRight[0], rightKneeFrontRight[1], rightKneeFrontRight[2]);
            gL.Vertex(rightShinFrontRight[0], rightShinFrontRight[1], rightShinFrontRight[2]);
            gL.End();
            ///////////////////
            ///////////////////
            ///Левая голень///
            float[] leftShinFrontRight = new float[] { 0.28f, -7.8f, 0.35f };
            float[] leftShinBackRight = new float[] { 0.23f, -7.8f, -0.2f };
            float[] leftShinFrontLeft = new float[] { 0.85f, -7.8f, 0.35f };
            float[] leftShinBackLeft = new float[] { 0.95f, -7.8f, -0.2f };
            ///////////////////
            gL.Color(1f, 1f, 0f);
            gL.Begin(OpenGL.GL_QUAD_STRIP);
                    gL.Vertex(leftKneeFrontRight[0], leftKneeFrontRight[1], leftKneeFrontRight[2]);
                    gL.Vertex(leftShinFrontRight[0], leftShinFrontRight[1], leftShinFrontRight[2]);
                    gL.Vertex(leftKneeBackRight[0], leftKneeBackRight[1], leftKneeBackRight[2]);
                    gL.Vertex(leftShinBackRight[0], leftShinBackRight[1], leftShinBackRight[2]);
                    gL.Vertex(leftKneeBackLeft[0], leftKneeBackLeft[1], leftKneeBackLeft[2]);
                    gL.Vertex(leftShinBackLeft[0], leftShinBackLeft[1], leftShinBackLeft[2]);
                    gL.Vertex(leftKneeFrontLeft[0], leftKneeFrontLeft[1], leftKneeFrontLeft[2]);
                    gL.Vertex(leftShinFrontLeft[0], leftShinFrontLeft[1], leftShinFrontLeft[2]);
                    gL.Vertex(leftKneeFrontRight[0], leftKneeFrontRight[1], leftKneeFrontRight[2]);
                    gL.Vertex(leftShinFrontRight[0], leftShinFrontRight[1], leftShinFrontRight[2]);
            gL.End();


        }

        private void DrawHemisphereByZ(int n, int k, float radius, OpenGL gL, float x, float y, float z)
        {
            var staticStartXZPoint = new PointF(x-radius, z);
            var startXZPoint = new PointF(x-radius, z);
            var nextXZPoint = new PointF();
            var tempXYPoint = new PointF();
            var tempXZPoint = new PointF();


            var nAngle = 360f / n;
            var kAngle = 90f / k;
            for (var i = 0; i < n; i++)
            {
                gL.Begin(OpenGL.GL_QUAD_STRIP);
                if (startXZPoint.Y <= z + 0.4f)
                    gL.Vertex(startXZPoint.X, y, startXZPoint.Y);
                nextXZPoint = new PointF(
                    x + (startXZPoint.X - x) * (float)Math.Cos(nAngle * Math.PI / 180) - (startXZPoint.Y - z) *
                        (float)Math.Sin(nAngle * Math.PI / 180),
                    z + (startXZPoint.X - x) * (float)Math.Sin(nAngle * Math.PI / 180) + (startXZPoint.Y - z) *
                        (float)Math.Cos(nAngle * Math.PI / 180));
                if (nextXZPoint.Y <= z + 0.4f)
                    gL.Vertex(nextXZPoint.X, y, nextXZPoint.Y);
                for (var j = 0; j < k; j++)
                {
                    tempXYPoint = new PointF(
                        x + (staticStartXZPoint.X - x) * (float)Math.Cos((j + 1) * kAngle * Math.PI / 180),   //часть формулы отпадает из-за умножения на 0
                        y + (staticStartXZPoint.X - x) * (float)Math.Sin((j + 1) * kAngle * Math.PI / 180));  //часть формулы отпадает из-за умножения на 0
                    tempXZPoint = new PointF(
                        x + (tempXYPoint.X - x) * (float)Math.Cos(i * nAngle * Math.PI / 180),    //часть формулы отпадает из-за умножения на 0
                        z + (tempXYPoint.X - x) * (float)Math.Sin(i * nAngle * Math.PI / 180));   //часть формулы отпадает из-за умножения на 0
                    if (tempXZPoint.Y <= z)
                        gL.Vertex(tempXZPoint.X, tempXYPoint.Y, tempXZPoint.Y);
                    tempXZPoint = new PointF(
                        x + (tempXYPoint.X - x) * (float)Math.Cos((i + 1) * nAngle * Math.PI / 180),      //часть формулы отпадает из-за умножения на 0
                        z + (tempXYPoint.X - x) * (float)Math.Sin((i + 1) * nAngle * Math.PI / 180));     //часть формулы отпадает из-за умножения на 0
                    if (tempXZPoint.Y <= z+0.4f)
                        gL.Vertex(tempXZPoint.X, tempXYPoint.Y, tempXZPoint.Y);
                }
                // Далее следует тупейшая реализация отрисовки второй половинки. Т.е.
                // всё заново пересчитывается, а разница только в том, что игреки с противоположными знаками.
                // И лучше хранить. Потом сделаю
                gL.End();
                gL.Begin(OpenGL.GL_QUAD_STRIP);
                if (startXZPoint.Y <= z + 0.4f)
                    gL.Vertex(startXZPoint.X, y, startXZPoint.Y);
                if (nextXZPoint.Y <= z + 0.4f)
                    gL.Vertex(nextXZPoint.X, y, nextXZPoint.Y);
                for (var j = 0; j < k; j++)
                {
                    tempXYPoint = new PointF(
                        x + (staticStartXZPoint.X - x) * (float)Math.Cos((j + 1) * kAngle * Math.PI / 180),   //часть формулы отпадает из-за умножения на 0
                        y + (staticStartXZPoint.X - x) * (float)Math.Sin((j + 1) * kAngle * Math.PI / 180));  //часть формулы отпадает из-за умножения на 0
                    tempXZPoint = new PointF(
                        x + (tempXYPoint.X - x) * (float)Math.Cos(i * nAngle * Math.PI / 180),    //часть формулы отпадает из-за умножения на 0
                        z + (tempXYPoint.X - x) * (float)Math.Sin(i * nAngle * Math.PI / 180));   //часть формулы отпадает из-за умножения на 0
                    if (tempXZPoint.Y <= z)
                        gL.Vertex(tempXZPoint.X, 2*y - tempXYPoint.Y, tempXZPoint.Y);
                    tempXZPoint = new PointF(
                        x + (tempXYPoint.X - x) * (float)Math.Cos((i + 1) * nAngle * Math.PI / 180),      //часть формулы отпадает из-за умножения на 0
                        z + (tempXYPoint.X - x) * (float)Math.Sin((i + 1) * nAngle * Math.PI / 180));     //часть формулы отпадает из-за умножения на 0
                    if (tempXZPoint.Y <= z + 0.4f)
                        gL.Vertex(tempXZPoint.X, 2*y - tempXYPoint.Y, tempXZPoint.Y);
                }
                startXZPoint = nextXZPoint;
                gL.End();
            }
        }

        private void DrawLaraNeckAndTorso(OpenGL gL)    //Зарисовка есть в блокноте на стр.52
        {
            ///Общие точки///
            ///Шея
            float[] farTopPointOfRightSideOfNeck = new float[] { -0.2f, 0.0f, -0.2f };    //Дальняя верхняя правая точка шеи
            float[] nearTopPointOfRightSideOfNeck = new float[] { -0.2f, 0.0f, 0.2f };    //Ближняя верхняя правая точка шеи
            float[] farTopPointOfLeftSideOfNeck = new float[] { 0.2f, 0.0f, -0.2f };    //Дальняя верхняя левая точка шеи
            float[] nearTopPointOfLeftSideOfNeck = new float[] { 0.2f, 0.0f, 0.2f };    //Ближняя верхняя левая точка шеи
            float[] farBottomPointOfRightSideOfNeck = new float[] { -0.3f, -0.8f, -0.3f };    //Дальняя нижняя правая точка шеи
            float[] nearBottomPointOfRightSideOfNeck = new float[] { -0.3f, -0.8f, 0.3f };    //Ближняя нижняя правая точка шеи
            float[] farBottomPointOfLeftSideOfNeck = new float[] { 0.3f, -0.8f, -0.3f };    //Дальняя нижняя левая точка шеи
            float[] nearBottomPointOfLeftSideOfNeck = new float[] { 0.3f, -0.8f, 0.3f };    //Ближняя нижняя левая точка шеи


            gL.Color(1f, 1f, 0f);
            gL.Begin(OpenGL.GL_QUADS);  //Верхняя часть шеи
                    gL.Vertex(farTopPointOfRightSideOfNeck[0], farTopPointOfRightSideOfNeck[1], farTopPointOfRightSideOfNeck[2]);
                    gL.Vertex(nearTopPointOfRightSideOfNeck[0], nearTopPointOfRightSideOfNeck[1], nearTopPointOfRightSideOfNeck[2]);
                    gL.Vertex(nearTopPointOfLeftSideOfNeck[0], nearTopPointOfLeftSideOfNeck[1], nearTopPointOfLeftSideOfNeck[2]);
                    gL.Vertex(farTopPointOfLeftSideOfNeck[0], farTopPointOfLeftSideOfNeck[1], farTopPointOfLeftSideOfNeck[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS);  //Нижняя часть шеи
                    gL.Vertex(farBottomPointOfRightSideOfNeck[0], farBottomPointOfRightSideOfNeck[1], farBottomPointOfRightSideOfNeck[2]);
                    gL.Vertex(nearBottomPointOfRightSideOfNeck[0], nearBottomPointOfRightSideOfNeck[1], nearBottomPointOfRightSideOfNeck[2]);
                    gL.Vertex(nearBottomPointOfLeftSideOfNeck[0], nearBottomPointOfLeftSideOfNeck[1], nearBottomPointOfLeftSideOfNeck[2]);
                    gL.Vertex(farBottomPointOfLeftSideOfNeck[0], farBottomPointOfLeftSideOfNeck[1], farBottomPointOfLeftSideOfNeck[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP); 
                    gL.Vertex(nearTopPointOfRightSideOfNeck[0], nearTopPointOfRightSideOfNeck[1], nearTopPointOfRightSideOfNeck[2]);
                    gL.Vertex(nearBottomPointOfRightSideOfNeck[0], nearBottomPointOfRightSideOfNeck[1], nearBottomPointOfRightSideOfNeck[2]);
                    gL.Vertex(farTopPointOfRightSideOfNeck[0], farTopPointOfRightSideOfNeck[1], farTopPointOfRightSideOfNeck[2]);
                    gL.Vertex(farBottomPointOfRightSideOfNeck[0], farBottomPointOfRightSideOfNeck[1], farBottomPointOfRightSideOfNeck[2]);
                    gL.Vertex(farTopPointOfLeftSideOfNeck[0], farTopPointOfLeftSideOfNeck[1], farTopPointOfLeftSideOfNeck[2]);
                    gL.Vertex(farBottomPointOfLeftSideOfNeck[0], farBottomPointOfLeftSideOfNeck[1], farBottomPointOfLeftSideOfNeck[2]);
                    gL.Vertex(nearTopPointOfLeftSideOfNeck[0], nearTopPointOfLeftSideOfNeck[1], nearTopPointOfLeftSideOfNeck[2]);
                    gL.Vertex(nearBottomPointOfLeftSideOfNeck[0], nearBottomPointOfLeftSideOfNeck[1], nearBottomPointOfLeftSideOfNeck[2]);
                    gL.Vertex(nearTopPointOfRightSideOfNeck[0], nearTopPointOfRightSideOfNeck[1], nearTopPointOfRightSideOfNeck[2]);
                    gL.Vertex(nearBottomPointOfRightSideOfNeck[0], nearBottomPointOfRightSideOfNeck[1], nearBottomPointOfRightSideOfNeck[2]);
            gL.End();
            



            ///Торс
            ///
            ///Плечи
            float[] farRightShoulder = new float[] { -1f, -0.8f, -0.4f };
            float[] nearRightShoulder = new float[] { -1f, -0.8f, 0.4f };
            float[] farLeftShoulder = new float[] { 1f, -0.8f, -0.4f };
            float[] nearLeftShoulder = new float[] { 1f, -0.8f, 0.4f };
            ///
            ///Грудь
            float[] rightChest = new float[] { -1f, -1.6f, 1.3f };
            float[] leftChest = new float[] { 1f, -1.6f, 1.3f };
            ///
            ///Низ грудной клетки
            float[] nearRightLowerChest = new float[] { -1f, -2.1f, 0.4f };
            float[] farRightLowerChest = new float[] { -1f, -2f, -0.5f };
            float[] nearLeftLowerChest = new float[] { 1f, -2.1f, 0.4f };
            float[] farLeftLowerChest = new float[] { 1f, -2f, -0.5f };
            ///
            ///Впуклость талии
            float[] nearRightLowerWaist = new float[] { -0.8f, -2.9f, 0.15f };
            float[] farRightLowerWaist = new float[] { -0.8f, -2.9f, -0.3f };
            float[] nearLeftLowerWaist = new float[] { 0.8f, -2.9f, 0.15f };
            float[] farLeftLowerWaist = new float[] { 0.8f, -2.9f, -0.3f };
            ///
            ///Верх таза
            float[] nearRightTopOfPelvis = new float[] { -0.85f, -3.4f, 0.3f };
            float[] farRightTopOfPelvis = new float[] { -0.85f, -3.4f, -0.5f };
            float[] nearLeftTopOfPelvis = new float[] { 0.85f, -3.4f, 0.3f };
            float[] farLeftTopOfPelvis = new float[] { 0.85f, -3.4f, -0.5f };


            gL.Color(0.52f, 0.8f, 0.92f);
            gL.Begin(OpenGL.GL_QUAD_STRIP); //Отрисовка передней стороны и задней
                    gL.Vertex(farRightShoulder[0], farRightShoulder[1], farRightShoulder[2]);
                    gL.Vertex(farLeftShoulder[0], farLeftShoulder[1], farLeftShoulder[2]);
                    gL.Vertex(nearRightShoulder[0], nearRightShoulder[1], nearRightShoulder[2]);
                    gL.Vertex(nearLeftShoulder[0], nearLeftShoulder[1], nearLeftShoulder[2]);
                    gL.Vertex(rightChest[0], rightChest[1], rightChest[2]);
                    gL.Vertex(leftChest[0], leftChest[1], leftChest[2]);
                    gL.Vertex(nearRightLowerChest[0], nearRightLowerChest[1], nearRightLowerChest[2]);
                    gL.Vertex(nearLeftLowerChest[0], nearLeftLowerChest[1], nearLeftLowerChest[2]);
                    gL.Vertex(nearRightLowerWaist[0], nearRightLowerWaist[1], nearRightLowerWaist[2]);
                    gL.Vertex(nearLeftLowerWaist[0], nearLeftLowerWaist[1], nearLeftLowerWaist[2]);
                    gL.Vertex(nearRightTopOfPelvis[0], nearRightTopOfPelvis[1], nearRightTopOfPelvis[2]);
                    gL.Vertex(nearLeftTopOfPelvis[0], nearLeftTopOfPelvis[1], nearLeftTopOfPelvis[2]);
                    gL.Vertex(farRightTopOfPelvis[0], farRightTopOfPelvis[1], farRightTopOfPelvis[2]);
                    gL.Vertex(farLeftTopOfPelvis[0], farLeftTopOfPelvis[1], farLeftTopOfPelvis[2]);
                    gL.Vertex(farRightLowerWaist[0], farRightLowerWaist[1], farRightLowerWaist[2]);
                    gL.Vertex(farLeftLowerWaist[0], farLeftLowerWaist[1], farLeftLowerWaist[2]);
                    gL.Vertex(farRightLowerChest[0], farRightLowerChest[1], farRightLowerChest[2]);
                    gL.Vertex(farLeftLowerChest[0], farLeftLowerChest[1], farLeftLowerChest[2]);
                    gL.Vertex(farRightShoulder[0], farRightShoulder[1], farRightShoulder[2]);
                    gL.Vertex(farLeftShoulder[0], farLeftShoulder[1], farLeftShoulder[2]);
            gL.End();
            
            gL.Begin(OpenGL.GL_TRIANGLE_STRIP); //Отрисовка правой стороны
                    gL.Vertex(nearRightShoulder[0], nearRightShoulder[1], nearRightShoulder[2]);
                    gL.Vertex(farRightShoulder[0], farRightShoulder[1], farRightShoulder[2]);
                    gL.Vertex(rightChest[0], rightChest[1], rightChest[2]);
                    gL.Vertex(farRightLowerChest[0], farRightLowerChest[1], farRightLowerChest[2]);
                    gL.Vertex(nearRightLowerChest[0], nearRightLowerChest[1], nearRightLowerChest[2]);
                    gL.Vertex(farRightLowerWaist[0], farRightLowerWaist[1], farRightLowerWaist[2]);
                    gL.Vertex(nearRightLowerWaist[0], nearRightLowerWaist[1], nearRightLowerWaist[2]);
                    gL.Vertex(farRightTopOfPelvis[0], farRightTopOfPelvis[1], farRightTopOfPelvis[2]);
                    gL.Vertex(nearRightTopOfPelvis[0], nearRightTopOfPelvis[1], nearRightTopOfPelvis[2]);
            gL.End();
            
            gL.Begin(OpenGL.GL_TRIANGLE_STRIP); //Отрисовка левой стороны
                    gL.Vertex(nearLeftShoulder[0], nearLeftShoulder[1], nearLeftShoulder[2]);
                    gL.Vertex(farLeftShoulder[0], farLeftShoulder[1], farLeftShoulder[2]);
                    gL.Vertex(leftChest[0], leftChest[1], leftChest[2]);
                    gL.Vertex(farLeftLowerChest[0], farLeftLowerChest[1], farLeftLowerChest[2]);
                    gL.Vertex(nearLeftLowerChest[0], nearLeftLowerChest[1], nearLeftLowerChest[2]);
                    gL.Vertex(farLeftLowerWaist[0], farLeftLowerWaist[1], farLeftLowerWaist[2]);
                    gL.Vertex(nearLeftLowerWaist[0], nearLeftLowerWaist[1], nearLeftLowerWaist[2]);
                    gL.Vertex(farLeftTopOfPelvis[0], farLeftTopOfPelvis[1], farLeftTopOfPelvis[2]);
                    gL.Vertex(nearLeftTopOfPelvis[0], nearLeftTopOfPelvis[1], nearLeftTopOfPelvis[2]);
            gL.End();


            ///Руки
            ///Правая рука
            ///Верхний квадрат плеча
            float[] rightHandTopQuadFarRightPoint = new float[] { -1.35f, -0.9f, -0.25f };
            float[] rightHandTopQuadNearRightPoint = new float[] { -1.35f, -0.9f, 0.25f };
            float[] rightHandTopQuadFarLeftPoint = new float[] { -1f, -0.9f, -0.25f };
            float[] rightHandTopQuadNearLeftPoint = new float[] { -1f, -0.9f, 0.25f };
            ///Средний квадрат плеча
            float[] rightHandMiddleQuadFarRightPoint = new float[] { -1.6f, -1.2f, -0.35f };
            float[] rightHandMiddleQuadNearRightPoint = new float[] { -1.6f, -1.2f, 0.35f };
            float[] rightHandMiddleQuadFarLeftPoint = new float[] { -1f, -1.2f, -0.35f };
            float[] rightHandMiddleQuadNearLeftPoint = new float[] { -1f, -1.2f, 0.35f };
            ///Нижний квадрат плеча
            float[] rightHandLowerQuadFarRightPoint = new float[] { -2f, -2.8f, -0.2f };
            float[] rightHandLowerQuadNearRightPoint = new float[] { -2f, -2.8f, 0.2f };
            float[] rightHandLowerQuadFarLeftPoint = new float[] { -1.6f, -2.8f, -0.2f };
            float[] rightHandLowerQuadNearLeftPoint = new float[] { -1.6f, -2.8f, 0.2f };
            ///Запястье
            float[] rightWristQuadFarRightPoint = new float[] { -1.95f, -4.5f, -0.15f };
            float[] rightWristQuadNearRightPoint = new float[] { -1.95f, -4.5f, 0.15f };
            float[] rightWristQuadFarLeftPoint = new float[] { -1.65f, -4.5f, -0.15f };
            float[] rightWristQuadNearLeftPoint = new float[] { -1.65f, -4.5f, 0.15f };




            gL.Color(1f, 1f, 0f);
            gL.Begin(OpenGL.GL_QUADS); //Отрисовка верхнего квадрата правой руки
                    gL.Vertex(rightHandTopQuadFarRightPoint[0], rightHandTopQuadFarRightPoint[1], rightHandTopQuadFarRightPoint[2]);
                    gL.Vertex(rightHandTopQuadFarLeftPoint[0], rightHandTopQuadFarLeftPoint[1], rightHandTopQuadFarLeftPoint[2]);
                    gL.Vertex(rightHandTopQuadNearLeftPoint[0], rightHandTopQuadNearLeftPoint[1], rightHandTopQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandTopQuadNearRightPoint[0], rightHandTopQuadNearRightPoint[1], rightHandTopQuadNearRightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS); //Отрисовка среднего квадрата правой руки
                    gL.Vertex(rightHandMiddleQuadFarRightPoint[0], rightHandMiddleQuadFarRightPoint[1], rightHandMiddleQuadFarRightPoint[2]);
                    gL.Vertex(rightHandMiddleQuadFarLeftPoint[0], rightHandMiddleQuadFarLeftPoint[1], rightHandMiddleQuadFarLeftPoint[2]);
                    gL.Vertex(rightHandMiddleQuadNearLeftPoint[0], rightHandMiddleQuadNearLeftPoint[1], rightHandMiddleQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandMiddleQuadNearRightPoint[0], rightHandMiddleQuadNearRightPoint[1], rightHandMiddleQuadNearRightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP);  //Соединение верхнего и среднего квадрата правой руки
                    gL.Vertex(rightHandTopQuadNearLeftPoint[0], rightHandTopQuadNearLeftPoint[1], rightHandTopQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandMiddleQuadNearLeftPoint[0], rightHandMiddleQuadNearLeftPoint[1], rightHandMiddleQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandTopQuadNearRightPoint[0], rightHandTopQuadNearRightPoint[1], rightHandTopQuadNearRightPoint[2]);
                    gL.Vertex(rightHandMiddleQuadNearRightPoint[0], rightHandMiddleQuadNearRightPoint[1], rightHandMiddleQuadNearRightPoint[2]);
                    gL.Vertex(rightHandTopQuadFarRightPoint[0], rightHandTopQuadFarRightPoint[1], rightHandTopQuadFarRightPoint[2]);
                    gL.Vertex(rightHandMiddleQuadFarRightPoint[0], rightHandMiddleQuadFarRightPoint[1], rightHandMiddleQuadFarRightPoint[2]);
                    gL.Vertex(rightHandTopQuadFarLeftPoint[0], rightHandTopQuadFarLeftPoint[1], rightHandTopQuadFarLeftPoint[2]);
                    gL.Vertex(rightHandMiddleQuadFarLeftPoint[0], rightHandMiddleQuadFarLeftPoint[1], rightHandMiddleQuadFarLeftPoint[2]);
                    gL.Vertex(rightHandTopQuadNearLeftPoint[0], rightHandTopQuadNearLeftPoint[1], rightHandTopQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandMiddleQuadNearLeftPoint[0], rightHandMiddleQuadNearLeftPoint[1], rightHandMiddleQuadNearLeftPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS); //Отрисовка нижнего квадрата правой руки
                    gL.Vertex(rightHandLowerQuadFarRightPoint[0], rightHandLowerQuadFarRightPoint[1], rightHandLowerQuadFarRightPoint[2]);
                    gL.Vertex(rightHandLowerQuadFarLeftPoint[0], rightHandLowerQuadFarLeftPoint[1], rightHandLowerQuadFarLeftPoint[2]);
                    gL.Vertex(rightHandLowerQuadNearLeftPoint[0], rightHandLowerQuadNearLeftPoint[1], rightHandLowerQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandLowerQuadNearRightPoint[0], rightHandLowerQuadNearRightPoint[1], rightHandLowerQuadNearRightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP);  //Соединение среднего и нижнего квадрата правой руки
                    gL.Vertex(rightHandMiddleQuadNearLeftPoint[0], rightHandMiddleQuadNearLeftPoint[1], rightHandMiddleQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandLowerQuadNearLeftPoint[0], rightHandLowerQuadNearLeftPoint[1], rightHandLowerQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandMiddleQuadNearRightPoint[0], rightHandMiddleQuadNearRightPoint[1], rightHandMiddleQuadNearRightPoint[2]);
                    gL.Vertex(rightHandLowerQuadNearRightPoint[0], rightHandLowerQuadNearRightPoint[1], rightHandLowerQuadNearRightPoint[2]);
                    gL.Vertex(rightHandMiddleQuadFarRightPoint[0], rightHandMiddleQuadFarRightPoint[1], rightHandMiddleQuadFarRightPoint[2]);
                    gL.Vertex(rightHandLowerQuadFarRightPoint[0], rightHandLowerQuadFarRightPoint[1], rightHandLowerQuadFarRightPoint[2]);
                    gL.Vertex(rightHandMiddleQuadFarLeftPoint[0], rightHandMiddleQuadFarLeftPoint[1], rightHandMiddleQuadFarLeftPoint[2]);
                    gL.Vertex(rightHandLowerQuadFarLeftPoint[0], rightHandLowerQuadFarLeftPoint[1], rightHandLowerQuadFarLeftPoint[2]);
                    gL.Vertex(rightHandMiddleQuadNearLeftPoint[0], rightHandMiddleQuadNearLeftPoint[1], rightHandMiddleQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandLowerQuadNearLeftPoint[0], rightHandLowerQuadNearLeftPoint[1], rightHandLowerQuadNearLeftPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS); //Отрисовка запястья
                    gL.Vertex(rightWristQuadFarRightPoint[0], rightWristQuadFarRightPoint[1], rightWristQuadFarRightPoint[2]);
                    gL.Vertex(rightWristQuadFarLeftPoint[0], rightWristQuadFarLeftPoint[1], rightWristQuadFarLeftPoint[2]);
                    gL.Vertex(rightWristQuadNearLeftPoint[0], rightWristQuadNearLeftPoint[1], rightWristQuadNearLeftPoint[2]);
                    gL.Vertex(rightWristQuadNearRightPoint[0], rightWristQuadNearRightPoint[1], rightWristQuadNearRightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP);  //Соединение нижнего квадрата правой руки и запястья
                    gL.Vertex(rightHandLowerQuadNearLeftPoint[0], rightHandLowerQuadNearLeftPoint[1], rightHandLowerQuadNearLeftPoint[2]);
                    gL.Vertex(rightWristQuadNearLeftPoint[0], rightWristQuadNearLeftPoint[1], rightWristQuadNearLeftPoint[2]);
                    gL.Vertex(rightHandLowerQuadNearRightPoint[0], rightHandLowerQuadNearRightPoint[1], rightHandLowerQuadNearRightPoint[2]);
                    gL.Vertex(rightWristQuadNearRightPoint[0], rightWristQuadNearRightPoint[1], rightWristQuadNearRightPoint[2]);
                    gL.Vertex(rightHandLowerQuadFarRightPoint[0], rightHandLowerQuadFarRightPoint[1], rightHandLowerQuadFarRightPoint[2]);
                    gL.Vertex(rightWristQuadFarRightPoint[0], rightWristQuadFarRightPoint[1], rightWristQuadFarRightPoint[2]);
                    gL.Vertex(rightHandLowerQuadFarLeftPoint[0], rightHandLowerQuadFarLeftPoint[1], rightHandLowerQuadFarLeftPoint[2]);
                    gL.Vertex(rightWristQuadFarLeftPoint[0], rightWristQuadFarLeftPoint[1], rightWristQuadFarLeftPoint[2]);
                    gL.Vertex(rightHandLowerQuadNearLeftPoint[0], rightHandLowerQuadNearLeftPoint[1], rightHandLowerQuadNearLeftPoint[2]);
                    gL.Vertex(rightWristQuadNearLeftPoint[0], rightWristQuadNearLeftPoint[1], rightWristQuadNearLeftPoint[2]);
            gL.End();



            ///
            ///
            ///Левая рука
            ///Верхний квадрат плеча
            float[] leftHandTopQuadFarRightPoint = new float[] { 1.35f, -0.9f, -0.25f };
            float[] leftHandTopQuadNearRightPoint = new float[] { 1.35f, -0.9f, 0.25f };
            float[] leftHandTopQuadFarLeftPoint = new float[] { 1f, -0.9f, -0.25f };
            float[] leftHandTopQuadNearLeftPoint = new float[] { 1f, -0.9f, 0.25f };
            ///Средний квадрат плеча
            float[] leftHandMiddleQuadFarRightPoint = new float[] { 1.6f, -1.2f, -0.35f };
            float[] leftHandMiddleQuadNearRightPoint = new float[] { 1.6f, -1.2f, 0.35f };
            float[] leftHandMiddleQuadFarLeftPoint = new float[] { 1f, -1.2f, -0.35f };
            float[] leftHandMiddleQuadNearLeftPoint = new float[] { 1f, -1.2f, 0.35f };
            ///Нижний квадрат плеча
            float[] leftHandLowerQuadFarRightPoint = new float[] { 2f, -2.8f, -0.2f };
            float[] leftHandLowerQuadNearRightPoint = new float[] { 2f, -2.8f, 0.2f };
            float[] leftHandLowerQuadFarLeftPoint = new float[] { 1.6f, -2.8f, -0.2f };
            float[] leftHandLowerQuadNearLeftPoint = new float[] { 1.6f, -2.8f, 0.2f };
            ///Запястье
            float[] leftWristQuadFarRightPoint = new float[] { 1.95f, -4.5f, -0.15f };
            float[] leftWristQuadNearRightPoint = new float[] { 1.95f, -4.5f, 0.15f };
            float[] leftWristQuadFarLeftPoint = new float[] { 1.65f, -4.5f, -0.15f };
            float[] leftWristQuadNearLeftPoint = new float[] { 1.65f, -4.5f, 0.15f };

            gL.Color(1f, 1f, 0f);
            gL.Begin(OpenGL.GL_QUADS); //Отрисовка верхнего квадрата левой руки
                    gL.Vertex(leftHandTopQuadFarRightPoint[0], leftHandTopQuadFarRightPoint[1], leftHandTopQuadFarRightPoint[2]);
                    gL.Vertex(leftHandTopQuadFarLeftPoint[0], leftHandTopQuadFarLeftPoint[1], leftHandTopQuadFarLeftPoint[2]);
                    gL.Vertex(leftHandTopQuadNearLeftPoint[0], leftHandTopQuadNearLeftPoint[1], leftHandTopQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandTopQuadNearRightPoint[0], leftHandTopQuadNearRightPoint[1], leftHandTopQuadNearRightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS); //Отрисовка среднего квадрата левой руки
                    gL.Vertex(leftHandMiddleQuadFarRightPoint[0], leftHandMiddleQuadFarRightPoint[1], leftHandMiddleQuadFarRightPoint[2]);
                    gL.Vertex(leftHandMiddleQuadFarLeftPoint[0], leftHandMiddleQuadFarLeftPoint[1], leftHandMiddleQuadFarLeftPoint[2]);
                    gL.Vertex(leftHandMiddleQuadNearLeftPoint[0], leftHandMiddleQuadNearLeftPoint[1], leftHandMiddleQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandMiddleQuadNearRightPoint[0], leftHandMiddleQuadNearRightPoint[1], leftHandMiddleQuadNearRightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP);  //Соединение верхнего и среднего квадрата левой руки
                    gL.Vertex(leftHandTopQuadNearLeftPoint[0], leftHandTopQuadNearLeftPoint[1], leftHandTopQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandMiddleQuadNearLeftPoint[0], leftHandMiddleQuadNearLeftPoint[1], leftHandMiddleQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandTopQuadNearRightPoint[0], leftHandTopQuadNearRightPoint[1], leftHandTopQuadNearRightPoint[2]);
                    gL.Vertex(leftHandMiddleQuadNearRightPoint[0], leftHandMiddleQuadNearRightPoint[1], leftHandMiddleQuadNearRightPoint[2]);
                    gL.Vertex(leftHandTopQuadFarRightPoint[0], leftHandTopQuadFarRightPoint[1], leftHandTopQuadFarRightPoint[2]);
                    gL.Vertex(leftHandMiddleQuadFarRightPoint[0], leftHandMiddleQuadFarRightPoint[1], leftHandMiddleQuadFarRightPoint[2]);
                    gL.Vertex(leftHandTopQuadFarLeftPoint[0], leftHandTopQuadFarLeftPoint[1], leftHandTopQuadFarLeftPoint[2]);
                    gL.Vertex(leftHandMiddleQuadFarLeftPoint[0], leftHandMiddleQuadFarLeftPoint[1], leftHandMiddleQuadFarLeftPoint[2]);
                    gL.Vertex(leftHandTopQuadNearLeftPoint[0], leftHandTopQuadNearLeftPoint[1], leftHandTopQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandMiddleQuadNearLeftPoint[0], leftHandMiddleQuadNearLeftPoint[1], leftHandMiddleQuadNearLeftPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS); //Отрисовка нижнего квадрата левой руки
                    gL.Vertex(leftHandLowerQuadFarRightPoint[0], leftHandLowerQuadFarRightPoint[1], leftHandLowerQuadFarRightPoint[2]);
                    gL.Vertex(leftHandLowerQuadFarLeftPoint[0], leftHandLowerQuadFarLeftPoint[1], leftHandLowerQuadFarLeftPoint[2]);
                    gL.Vertex(leftHandLowerQuadNearLeftPoint[0], leftHandLowerQuadNearLeftPoint[1], leftHandLowerQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandLowerQuadNearRightPoint[0], leftHandLowerQuadNearRightPoint[1], leftHandLowerQuadNearRightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP);  //Соединение среднего и нижнего квадрата левой руки
                    gL.Vertex(leftHandMiddleQuadNearLeftPoint[0], leftHandMiddleQuadNearLeftPoint[1], leftHandMiddleQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandLowerQuadNearLeftPoint[0], leftHandLowerQuadNearLeftPoint[1], leftHandLowerQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandMiddleQuadNearRightPoint[0], leftHandMiddleQuadNearRightPoint[1], leftHandMiddleQuadNearRightPoint[2]);
                    gL.Vertex(leftHandLowerQuadNearRightPoint[0], leftHandLowerQuadNearRightPoint[1], leftHandLowerQuadNearRightPoint[2]);
                    gL.Vertex(leftHandMiddleQuadFarRightPoint[0], leftHandMiddleQuadFarRightPoint[1], leftHandMiddleQuadFarRightPoint[2]);
                    gL.Vertex(leftHandLowerQuadFarRightPoint[0], leftHandLowerQuadFarRightPoint[1], leftHandLowerQuadFarRightPoint[2]);
                    gL.Vertex(leftHandMiddleQuadFarLeftPoint[0], leftHandMiddleQuadFarLeftPoint[1], leftHandMiddleQuadFarLeftPoint[2]);
                    gL.Vertex(leftHandLowerQuadFarLeftPoint[0], leftHandLowerQuadFarLeftPoint[1], leftHandLowerQuadFarLeftPoint[2]);
                    gL.Vertex(leftHandMiddleQuadNearLeftPoint[0], leftHandMiddleQuadNearLeftPoint[1], leftHandMiddleQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandLowerQuadNearLeftPoint[0], leftHandLowerQuadNearLeftPoint[1], leftHandLowerQuadNearLeftPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUADS); //Отрисовка запястья
                    gL.Vertex(leftWristQuadFarRightPoint[0], leftWristQuadFarRightPoint[1], leftWristQuadFarRightPoint[2]);
                    gL.Vertex(leftWristQuadFarLeftPoint[0], leftWristQuadFarLeftPoint[1], leftWristQuadFarLeftPoint[2]);
                    gL.Vertex(leftWristQuadNearLeftPoint[0], leftWristQuadNearLeftPoint[1], leftWristQuadNearLeftPoint[2]);
                    gL.Vertex(leftWristQuadNearRightPoint[0], leftWristQuadNearRightPoint[1], leftWristQuadNearRightPoint[2]);
            gL.End();
            gL.Begin(OpenGL.GL_QUAD_STRIP);  //Соединение нижнего квадрата левой руки и запястья
                    gL.Vertex(leftHandLowerQuadNearLeftPoint[0], leftHandLowerQuadNearLeftPoint[1], leftHandLowerQuadNearLeftPoint[2]);
                    gL.Vertex(leftWristQuadNearLeftPoint[0], leftWristQuadNearLeftPoint[1], leftWristQuadNearLeftPoint[2]);
                    gL.Vertex(leftHandLowerQuadNearRightPoint[0], leftHandLowerQuadNearRightPoint[1], leftHandLowerQuadNearRightPoint[2]);
                    gL.Vertex(leftWristQuadNearRightPoint[0], leftWristQuadNearRightPoint[1], leftWristQuadNearRightPoint[2]);
                    gL.Vertex(leftHandLowerQuadFarRightPoint[0], leftHandLowerQuadFarRightPoint[1], leftHandLowerQuadFarRightPoint[2]);
                    gL.Vertex(leftWristQuadFarRightPoint[0], leftWristQuadFarRightPoint[1], leftWristQuadFarRightPoint[2]);
                    gL.Vertex(leftHandLowerQuadFarLeftPoint[0], leftHandLowerQuadFarLeftPoint[1], leftHandLowerQuadFarLeftPoint[2]);
                    gL.Vertex(leftWristQuadFarLeftPoint[0], leftWristQuadFarLeftPoint[1], leftWristQuadFarLeftPoint[2]);
                    gL.Vertex(leftHandLowerQuadNearLeftPoint[0], leftHandLowerQuadNearLeftPoint[1], leftHandLowerQuadNearLeftPoint[2]);
                    gL.Vertex(leftWristQuadNearLeftPoint[0], leftWristQuadNearLeftPoint[1], leftWristQuadNearLeftPoint[2]);
            gL.End();
        }

        private void DrawLaraFace(OpenGL gL)    //Зарисовка есть в блокноте на стр.44
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
            gL.Color(0.59f, 0.52f, 0.25f);
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
