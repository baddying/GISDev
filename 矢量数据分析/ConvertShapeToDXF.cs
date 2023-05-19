using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace EditSDELayerDemo
{
    public class ConvertShapeToDXF
    {
        public delegate void OnCompleted(object sender, ConvertShapeToDXFArgs e);
        public event OnCompleted completed;
        struct ColorDXF
        {
            public byte Red;
            public byte Green;
            public byte Blue;
            public ColorDXF(byte r, byte g, byte b)
            {
                Red = r;
                Green = g;
                Blue = b;
            }
        }
        struct TagDXF
        {
            public const string HEADER = "HEADER";
            public const string TABLES = "TABLES";
            public const string ENTITIES = "ENTITIES";
            public const string BLOCKS = "BLOCKS";
        }

        string m_Filename = null;
        IFeatureLayer m_FeatureLayer = null;
        TextWriter m_cadTextWriter = null;
        public ConvertShapeToDXF(string filename, IFeatureLayer featureLayer)
        {
            m_Filename = filename;
            m_FeatureLayer = featureLayer;
        }

        public void Convert()
        {
            if ((m_FeatureLayer == null) || (string.IsNullOrEmpty(m_Filename)))
            {
                completed(this, new ConvertShapeToDXFArgs(new Exception("没有获得需要转换的图层要素！")));
            }
            try
            {
                m_cadTextWriter = new StreamWriter(m_Filename);
                IEnvelope envelope = m_FeatureLayer.AreaOfInterest;
                IFeatureClass featureClass = m_FeatureLayer.FeatureClass;
                Header(envelope);
                Tables();
                Blocks();
                Entities();
                completed(this, new ConvertShapeToDXFArgs());
            }
            catch (Exception ex)
            {
                completed(this, new ConvertShapeToDXFArgs(ex));
            }
            finally
            {
                m_cadTextWriter.Close();
                m_cadTextWriter.Dispose();
                m_cadTextWriter = null;
            }
        }

        /// <summary> 
        /// return color nearest Autocad 
        /// </summary> 
        /// <param name="intR"></param> 
        /// <param name="intG"></param> 
        /// <param name="intB"></param> 
        /// <returns></returns> 
        static ColorDXF GetColorDXF(ColorDXF c)
        {
            IDictionary<byte, string> dct = new Dictionary<byte, string>();
            #region Dictionary Color
            //item: colore come valore RGB, key: colore equivalent in AutoCAD 
            dct.Add(0, "0|0|0");
            dct.Add(1, "255|0|0");
            dct.Add(2, "255|255|0");
            dct.Add(3, "0|255|0");
            dct.Add(4, "0|255|255");
            dct.Add(5, "0|0|255");
            dct.Add(6, "255|0|255");
            dct.Add(7, "255|255|255");
            dct.Add(8, "65|65|65");
            dct.Add(9, "128|128|128");
            dct.Add(10, "255|0|0");
            dct.Add(11, "255|170|170");
            dct.Add(12, "189|0|0");
            dct.Add(13, "189|126|126");
            dct.Add(14, "129|0|0");
            dct.Add(15, "129|86|86");
            dct.Add(16, "104|0|0");
            dct.Add(17, "104|69|69");
            dct.Add(18, "79|0|0");
            dct.Add(19, "79|53|53");
            dct.Add(20, "255|63|0");
            dct.Add(21, "255|191|170");
            dct.Add(22, "189|46|0");
            dct.Add(23, "189|141|126");
            dct.Add(24, "129|31|0");
            dct.Add(25, "129|96|86");
            dct.Add(26, "104|25|0");
            dct.Add(27, "104|78|69");
            dct.Add(28, "79|19|0");
            dct.Add(29, "79|59|53");
            dct.Add(30, "255|127|0");
            dct.Add(31, "255|212|170");
            dct.Add(32, "189|94|0");
            dct.Add(33, "189|157|126");
            dct.Add(34, "129|64|0");
            dct.Add(35, "129|107|86");
            dct.Add(36, "104|52|0");
            dct.Add(37, "104|86|69");
            dct.Add(38, "79|39|0");
            dct.Add(39, "79|66|53");
            dct.Add(40, "255|191|0");
            dct.Add(41, "255|234|170");
            dct.Add(42, "189|141|0");
            dct.Add(43, "189|173|126");
            dct.Add(44, "129|96|0");
            dct.Add(45, "129|118|86");
            dct.Add(46, "104|78|0");
            dct.Add(47, "104|95|69");
            dct.Add(48, "79|59|0");
            dct.Add(49, "79|73|53");
            dct.Add(50, "255|255|0");
            dct.Add(51, "255|255|170");
            dct.Add(52, "189|189|0");
            dct.Add(53, "189|189|126");
            dct.Add(54, "129|129|0");
            dct.Add(55, "129|129|86");
            dct.Add(56, "104|104|0");
            dct.Add(57, "104|104|69");
            dct.Add(58, "79|79|0");
            dct.Add(59, "79|79|53");
            dct.Add(60, "191|255|0");
            dct.Add(61, "234|255|170");
            dct.Add(62, "141|189|0");
            dct.Add(63, "173|189|126");
            dct.Add(64, "96|129|0");
            dct.Add(65, "118|129|86");
            dct.Add(66, "78|104|0");
            dct.Add(67, "95|104|69");
            dct.Add(68, "59|79|0");
            dct.Add(69, "73|79|53");
            dct.Add(70, "127|255|0");
            dct.Add(71, "212|255|170");
            dct.Add(72, "94|189|0");
            dct.Add(73, "157|189|126");
            dct.Add(74, "64|129|0");
            dct.Add(75, "107|129|86");
            dct.Add(76, "52|104|0");
            dct.Add(77, "86|104|69");
            dct.Add(78, "39|79|0");
            dct.Add(79, "66|79|53");
            dct.Add(80, "63|255|0");
            dct.Add(81, "191|255|170");
            dct.Add(82, "46|189|0");
            dct.Add(83, "141|189|126");
            dct.Add(84, "31|129|0");
            dct.Add(85, "96|129|86");
            dct.Add(86, "25|104|0");
            dct.Add(87, "78|104|69");
            dct.Add(88, "19|79|0");
            dct.Add(89, "59|79|53");
            dct.Add(90, "0|255|0");
            dct.Add(91, "170|255|170");
            dct.Add(92, "0|189|0");
            dct.Add(93, "126|189|126");
            dct.Add(94, "0|129|0");
            dct.Add(95, "86|129|86");
            dct.Add(96, "0|104|0");
            dct.Add(97, "69|104|69");
            dct.Add(98, "0|79|0");
            dct.Add(99, "53|79|53");
            dct.Add(100, "0|255|63");
            dct.Add(101, "170|255|191");
            dct.Add(102, "0|189|46");
            dct.Add(103, "126|189|141");
            dct.Add(104, "0|129|31");
            dct.Add(105, "86|129|96");
            dct.Add(106, "0|104|25");
            dct.Add(107, "69|104|78");
            dct.Add(108, "0|79|19");
            dct.Add(109, "53|79|59");
            dct.Add(110, "0|255|127");
            dct.Add(111, "170|255|212");
            dct.Add(112, "0|189|94");
            dct.Add(113, "126|189|157");
            dct.Add(114, "0|129|64");
            dct.Add(115, "86|129|107");
            dct.Add(116, "0|104|52");
            dct.Add(117, "69|104|86");
            dct.Add(118, "0|79|39");
            dct.Add(119, "53|79|66");
            dct.Add(120, "0|255|191");
            dct.Add(121, "170|255|234");
            dct.Add(122, "0|189|141");
            dct.Add(123, "126|189|173");
            dct.Add(124, "0|129|96");
            dct.Add(125, "86|129|118");
            dct.Add(126, "0|104|78");
            dct.Add(127, "69|104|95");
            dct.Add(128, "0|79|59");
            dct.Add(129, "53|79|73");
            dct.Add(130, "0|255|255");
            dct.Add(131, "170|255|255");
            dct.Add(132, "0|189|189");
            dct.Add(133, "126|189|189");
            dct.Add(134, "0|129|129");
            dct.Add(135, "86|129|129");
            dct.Add(136, "0|104|104");
            dct.Add(137, "69|104|104");
            dct.Add(138, "0|79|79");
            dct.Add(139, "53|79|79");
            dct.Add(140, "0|191|255");
            dct.Add(141, "170|234|255");
            dct.Add(142, "0|141|189");
            dct.Add(143, "126|173|189");
            dct.Add(144, "0|96|129");
            dct.Add(145, "86|118|129");
            dct.Add(146, "0|78|104");
            dct.Add(147, "69|95|104");
            dct.Add(148, "0|59|79");
            dct.Add(149, "53|73|79");
            dct.Add(150, "0|127|255");
            dct.Add(151, "170|212|255");
            dct.Add(152, "0|94|189");
            dct.Add(153, "126|157|189");
            dct.Add(154, "0|64|129");
            dct.Add(155, "86|107|129");
            dct.Add(156, "0|52|104");
            dct.Add(157, "69|86|104");
            dct.Add(158, "0|39|79");
            dct.Add(159, "53|66|79");
            dct.Add(160, "0|63|255");
            dct.Add(161, "170|191|255");
            dct.Add(162, "0|46|189");
            dct.Add(163, "126|141|189");
            dct.Add(164, "0|31|129");
            dct.Add(165, "86|96|129");
            dct.Add(166, "0|25|104");
            dct.Add(167, "69|78|104");
            dct.Add(168, "0|19|79");
            dct.Add(169, "53|59|79");
            dct.Add(170, "0|0|255");
            dct.Add(171, "170|170|255");
            dct.Add(172, "0|0|189");
            dct.Add(173, "126|126|189");
            dct.Add(174, "0|0|129");
            dct.Add(175, "86|86|129");
            dct.Add(176, "0|0|104");
            dct.Add(177, "69|69|104");
            dct.Add(178, "0|0|79");
            dct.Add(179, "53|53|79");
            dct.Add(180, "63|0|255");
            dct.Add(181, "191|170|255");
            dct.Add(182, "46|0|189");
            dct.Add(183, "141|126|189");
            dct.Add(184, "31|0|129");
            dct.Add(185, "96|86|129");
            dct.Add(186, "25|0|104");
            dct.Add(187, "78|69|104");
            dct.Add(188, "19|0|79");
            dct.Add(189, "59|53|79");
            dct.Add(190, "127|0|255");
            dct.Add(191, "212|170|255");
            dct.Add(192, "94|0|189");
            dct.Add(193, "157|126|189");
            dct.Add(194, "64|0|129");
            dct.Add(195, "107|86|129");
            dct.Add(196, "52|0|104");
            dct.Add(197, "86|69|104");
            dct.Add(198, "39|0|79");
            dct.Add(199, "66|53|79");
            dct.Add(200, "191|0|255");
            dct.Add(201, "234|170|255");
            dct.Add(202, "141|0|189");
            dct.Add(203, "173|126|189");
            dct.Add(204, "96|0|129");
            dct.Add(205, "118|86|129");
            dct.Add(206, "78|0|104");
            dct.Add(207, "95|69|104");
            dct.Add(208, "59|0|79");
            dct.Add(209, "73|53|79");
            dct.Add(210, "255|0|255");
            dct.Add(211, "255|170|255");
            dct.Add(212, "189|0|189");
            dct.Add(213, "189|126|189");
            dct.Add(214, "129|0|129");
            dct.Add(215, "129|86|129");
            dct.Add(216, "104|0|104");
            dct.Add(217, "104|69|104");
            dct.Add(218, "79|0|79");
            dct.Add(219, "79|53|79");
            dct.Add(220, "255|0|191");
            dct.Add(221, "255|170|234");
            dct.Add(222, "189|0|141");
            dct.Add(223, "189|126|173");
            dct.Add(224, "129|0|96");
            dct.Add(225, "129|86|118");
            dct.Add(226, "104|0|78");
            dct.Add(227, "104|69|95");
            dct.Add(228, "79|0|59");
            dct.Add(229, "79|53|73");
            dct.Add(230, "255|0|127");
            dct.Add(231, "255|170|212");
            dct.Add(232, "189|0|94");
            dct.Add(233, "189|126|157");
            dct.Add(234, "129|0|64");
            dct.Add(235, "129|86|107");
            dct.Add(236, "104|0|52");
            dct.Add(237, "104|69|86");
            dct.Add(238, "79|0|39");
            dct.Add(239, "79|53|66");
            dct.Add(240, "255|0|63");
            dct.Add(241, "255|170|191");
            dct.Add(242, "189|0|46");
            dct.Add(243, "189|126|141");
            dct.Add(244, "129|0|31");
            dct.Add(245, "129|86|96");
            dct.Add(246, "104|0|25");
            dct.Add(247, "104|69|78");
            dct.Add(248, "79|0|19");
            dct.Add(249, "79|53|59");
            dct.Add(250, "51|51|51");
            dct.Add(251, "80|80|80");
            dct.Add(252, "105|105|105");
            dct.Add(253, "130|130|130");
            dct.Add(254, "190|190|190");
            dct.Add(255, "255|255|255");

            #endregion Dictionary Color
            string[] sColorCAD;  //tutti possibili colori della collection 
            byte bGCAD, bRCAD, bBCAD; //valori RGB di tutti colori 
            byte color = 0;
            //color nearest of collection 
            double dblTemp = Double.MaxValue;
            double dblDistance;
            foreach (byte idx in dct.Keys)
            {
                sColorCAD = dct[idx].Split('|');
                bRCAD = byte.Parse(sColorCAD[0]);
                bGCAD = byte.Parse(sColorCAD[1]);
                bBCAD = byte.Parse(sColorCAD[2]);
                dblDistance = System.Math.Sqrt((bRCAD - c.Red) ^ 2 + (bGCAD - c.Green) ^ 2 + (bBCAD - c.Blue) ^ 2);
                if (dblDistance <= dblTemp)
                {
                    dblTemp = dblDistance;
                    color = idx;
                    if (dblTemp == 0)
                        break;
                }
            }
            if (color == 0)
                color = 7;
            string[] r = dct[color].Split('|');
            return new ColorDXF(byte.Parse(r[0]), byte.Parse(r[1]), byte.Parse(r[2]));
        }
        static IFormatProvider GetFormatProvider()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencyDecimalSeparator = ".";
            return nfi;
        }

        void BeginSection(string Tag)
        {
            m_cadTextWriter.WriteLine(0);
            m_cadTextWriter.WriteLine("SECTION");
            m_cadTextWriter.WriteLine(2);
            m_cadTextWriter.WriteLine(Tag);
        }
        void EndSection()
        {
            m_cadTextWriter.WriteLine(0);
            m_cadTextWriter.WriteLine("ENDSEC");
        }

        void EOF()
        {
            m_cadTextWriter.WriteLine(0);
            m_cadTextWriter.WriteLine("EOF");
        }

        void Point(IPointCollection pPoints, string LayerName, byte? Color)
        {
            for (int i = 0; i < pPoints.PointCount; i++)
            {
                Point(pPoints.get_Point(i), LayerName, Color);
            }

        }

        void Blocks()
        {
            BeginSection(TagDXF.BLOCKS);
            EndSection();
        }

        void Tables()
        {
            BeginSection(TagDXF.TABLES);
            EndSection();
        }

        void Point(IPoint pPoint, string LayerName, byte? Color)
        {
            m_cadTextWriter.WriteLine(0);
            m_cadTextWriter.WriteLine("POINT");
            m_cadTextWriter.WriteLine(8);
            m_cadTextWriter.WriteLine(LayerName);
            m_cadTextWriter.WriteLine(62);
            if (Color != null)
                m_cadTextWriter.WriteLine(Color);

            m_cadTextWriter.WriteLine(10);
            m_cadTextWriter.WriteLine(pPoint.X.ToString(GetFormatProvider()));
            m_cadTextWriter.WriteLine(20);
            m_cadTextWriter.WriteLine(pPoint.Y.ToString(GetFormatProvider()));

            m_cadTextWriter.WriteLine(39); 
            m_cadTextWriter.WriteLine(3);
        }
        void Header(IEnvelope extent)
        {
          
            IPoint LLExtents = extent.LowerLeft;
            IPoint URExtents = extent.UpperRight;

            BeginSection(TagDXF.HEADER);

            m_cadTextWriter.WriteLine(9);
            m_cadTextWriter.WriteLine("$EXTMIN");
            m_cadTextWriter.WriteLine(10);
            m_cadTextWriter.WriteLine(LLExtents.X.ToString(GetFormatProvider()));
            m_cadTextWriter.WriteLine(20);
            m_cadTextWriter.WriteLine(LLExtents.Y.ToString(GetFormatProvider()));
            m_cadTextWriter.WriteLine(30);
            m_cadTextWriter.WriteLine(0);
            m_cadTextWriter.WriteLine(9);
            m_cadTextWriter.WriteLine("$EXTMAX");
            m_cadTextWriter.WriteLine(10);
            m_cadTextWriter.WriteLine(URExtents.X.ToString(GetFormatProvider()));
            m_cadTextWriter.WriteLine(20);
            m_cadTextWriter.WriteLine(URExtents.Y.ToString(GetFormatProvider()));
            m_cadTextWriter.WriteLine(30);
            m_cadTextWriter.WriteLine(0);

            EndSection();

        }
        void Polyline(IGeometry pShape, string LayerName, byte? Color)
        {
            IGeometryCollection geometryCollection;
            if (pShape is IGeometryCollection)
                geometryCollection = pShape as IGeometryCollection;
            else
            {
                object o = Type.Missing;
                geometryCollection = new Polygon() as IGeometryCollection;
                geometryCollection.AddGeometry(pShape, ref o, ref o);
            }
            for (int j = 0; j < geometryCollection.GeometryCount; j++)
            {
                ISegmentCollection pSegColl = geometryCollection.get_Geometry(j) as ISegmentCollection;

                bool bFirstSeg = true;
                ICircularArc pCA = null;
                ISegment pSeg = null;
                for (int i = 0; i < pSegColl.SegmentCount; i++)
                {
                    pSeg = pSegColl.get_Segment(i);
                    switch (pSeg.GeometryType)
                    {
                        case esriGeometryType.esriGeometryLine:

                            if (bFirstSeg)
                            {

                                m_cadTextWriter.WriteLine(0);
                                m_cadTextWriter.WriteLine("POLYLINE");

                                m_cadTextWriter.WriteLine(8);
                                m_cadTextWriter.WriteLine(LayerName);
                                m_cadTextWriter.WriteLine(66);
                                m_cadTextWriter.WriteLine(1);
                                if (Color != null)
                                {
                                    m_cadTextWriter.WriteLine(62);
                                    m_cadTextWriter.WriteLine(Color);
                                }

                                m_cadTextWriter.WriteLine(6);
                                m_cadTextWriter.WriteLine("CONTINUOUS");

                                m_cadTextWriter.WriteLine(0);
                                m_cadTextWriter.WriteLine("VERTEX");
                                m_cadTextWriter.WriteLine(8);
                                m_cadTextWriter.WriteLine(LayerName);
                                m_cadTextWriter.WriteLine(10);
                                m_cadTextWriter.WriteLine(pSeg.FromPoint.X.ToString(GetFormatProvider()));
                                m_cadTextWriter.WriteLine(20);
                                m_cadTextWriter.WriteLine(pSeg.FromPoint.Y.ToString(GetFormatProvider()));
                                bFirstSeg = !bFirstSeg;
                            }

                            m_cadTextWriter.WriteLine(0);
                            m_cadTextWriter.WriteLine("VERTEX");
                            m_cadTextWriter.WriteLine(8);
                            m_cadTextWriter.WriteLine(LayerName);

                            m_cadTextWriter.WriteLine(10);
                            m_cadTextWriter.WriteLine(pSeg.ToPoint.X.ToString(GetFormatProvider()));
                            m_cadTextWriter.WriteLine(20);
                            m_cadTextWriter.WriteLine(pSeg.ToPoint.Y.ToString(GetFormatProvider()));
                            if (i == (pSegColl.SegmentCount - 1))
                            {
                                m_cadTextWriter.WriteLine(0);
                                m_cadTextWriter.WriteLine("SEQEND");
                                m_cadTextWriter.WriteLine(8);
                                m_cadTextWriter.WriteLine(LayerName);
                            }
                            break;
                        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryCircularArc:
                            if (!bFirstSeg)
                            {
                                m_cadTextWriter.WriteLine(0);
                                m_cadTextWriter.WriteLine("SEQEND");
                                m_cadTextWriter.WriteLine(8);
                                m_cadTextWriter.WriteLine(LayerName);
                            }
                            pCA = pSeg as ICircularArc;
                            m_cadTextWriter.WriteLine(0);
                            m_cadTextWriter.WriteLine("ARC");
                            m_cadTextWriter.WriteLine(8);
                            m_cadTextWriter.WriteLine(LayerName);
                            m_cadTextWriter.WriteLine(10);
                            m_cadTextWriter.WriteLine(pCA.CenterPoint.X.ToString(GetFormatProvider()));
                            m_cadTextWriter.WriteLine(20);
                            m_cadTextWriter.WriteLine(pCA.CenterPoint.Y.ToString(GetFormatProvider()));
                            m_cadTextWriter.WriteLine(40);
                            m_cadTextWriter.WriteLine(pCA.Radius);
                            string sFromAngle = (pCA.FromAngle * 180 / Math.PI).ToString(GetFormatProvider());
                            string sToAngle = (pCA.ToAngle * 180 / Math.PI).ToString(GetFormatProvider());
                            m_cadTextWriter.WriteLine(50);
                            m_cadTextWriter.WriteLine(pCA.IsCounterClockwise ? sFromAngle : sToAngle);
                            m_cadTextWriter.WriteLine(51);
                            m_cadTextWriter.WriteLine(pCA.IsCounterClockwise ? sToAngle : sFromAngle);
                            bFirstSeg = true;
                            break;
                    }
                }
            }
        }
        void Polygon(IGeometry pShape, string LayerName, byte? Color)
        {
            IPolygon4 polygon = null;
            IGeometryBag exteriorRings = null;
            try
            {
                polygon = pShape as IPolygon4;
                 exteriorRings = polygon.ExteriorRingBag;
            }
            catch
            {
                IPointCollection pPointCollection = pShape as IPointCollection;
                IPointCollection newPointCollection = new PolygonClass();
                for (int i = 0; i < pPointCollection.PointCount; i++)
                {
                    newPointCollection.AddPoint(pPointCollection.get_Point(i));
                }
                IGeometry pGeometry = newPointCollection as IGeometry;
                ITopologicalOperator pTopoOpe = (ITopologicalOperator)pGeometry;
                pTopoOpe.Simplify();
                polygon = pGeometry as IPolygon4;
                exteriorRings = polygon.ExteriorRingBag;
            }
            //For each exterior rings find the interior rings associated with it 
            IEnumGeometry exteriorRingsEnum = exteriorRings as IEnumGeometry;
            exteriorRingsEnum.Reset();
            IRing currentExteriorRing = exteriorRingsEnum.Next() as IRing;
            while (currentExteriorRing != null)
            {
                Polyline(currentExteriorRing, LayerName, Color);
                IGeometryBag interiorRings = polygon.get_InteriorRingBag(currentExteriorRing);
                IEnumGeometry interiorRingsEnum = interiorRings as IEnumGeometry;
                interiorRingsEnum.Reset();
                IRing currentInteriorRing = interiorRingsEnum.Next() as IRing;
                while (currentInteriorRing != null)
                {
                    Polyline(currentInteriorRing, LayerName, Color);
                    currentInteriorRing = interiorRingsEnum.Next() as IRing;
                }

                currentExteriorRing = exteriorRingsEnum.Next() as IRing;

            }
        }

        void Entities()
        {
            BeginSection(TagDXF.ENTITIES);
            byte? Color = 7;
            string LayerName = m_FeatureLayer.Name;
            IFeatureClass featureClass = m_FeatureLayer.FeatureClass;
            IFeatureCursor featureCursor = featureClass.Search(null, true);
            IFeature feature = featureCursor.NextFeature();
            IGeometry shape = null;
            while (feature != null)
            {
                shape = feature.ShapeCopy;
                switch (shape.GeometryType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        Point(shape as IPoint, LayerName, Color);
                        break;
                    case esriGeometryType.esriGeometryMultipoint:
                        Point(shape as IPointCollection, LayerName, Color);
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        Polyline(shape, LayerName, Color);
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        Polygon(shape, LayerName, Color);
                        break;
                    case esriGeometryType.esriGeometryEnvelope:
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPath:
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryAny:
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryRing:
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryLine:
                        Polyline(shape, LayerName, Color);
                        break;
                    case esriGeometryType.esriGeometryCircularArc:
                    case esriGeometryType.esriGeometryBezier3Curve:
                    case esriGeometryType.esriGeometryEllipticArc:
                        break;
                }
                feature = featureCursor.NextFeature();
            }
            EndSection();
            EOF();
        }

    }

    public class ConvertShapeToDXFArgs : System.EventArgs
    {
        bool result = false;
        Exception ex = null;
        public ConvertShapeToDXFArgs()
        {
            result = true;
        }
        public ConvertShapeToDXFArgs(Exception ex)
        {
            this.ex = ex;
        }
        public bool Result
        {
            get { return result; }
        }
        public Exception Exception
        {
            get { return ex; }
        }
    }
}
