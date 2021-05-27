﻿using System.Collections.Generic;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.ProfileResource;

namespace SAM.Geometry.IFC
{
    public static partial class Create
    {
        public static IfcProfileDef IfcProfileDef(this Xbim.Common.IModel model, Planar.Face2D face2D, IfcProfileTypeEnum ifcProfileTypeEnum)
        {
            if(face2D == null || model == null)
            {
                return null;
            }

            List<Planar.IClosed2D> internalEdge2Ds = face2D.InternalEdge2Ds;
            if(internalEdge2Ds == null || internalEdge2Ds.Count == 0)
            {
                Planar.IClosed2D externalEdge2D = face2D.ExternalEdge2D;
                if(externalEdge2D == null)
                {
                    return null;
                }

                if(externalEdge2D is Planar.Rectangle2D)
                {
                    return IfcRectangleProfileDef(model, (Planar.Rectangle2D)externalEdge2D, ifcProfileTypeEnum);
                }
                else
                {
                    return IfcArbitraryClosedProfileDef(model, externalEdge2D as dynamic, ifcProfileTypeEnum);
                }
            }
            else
            {
                return IfcArbitraryProfileDefWithVoids(model, face2D, ifcProfileTypeEnum);
            }

            return null;
        }
    }
}