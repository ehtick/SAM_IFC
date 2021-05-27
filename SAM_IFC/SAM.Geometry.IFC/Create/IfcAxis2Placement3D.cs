﻿using Xbim.Ifc4.GeometryResource;

namespace SAM.Geometry.IFC
{
    public static partial class Create
    {
        public static IfcAxis2Placement3D IfcAxis2Placement3D(this Xbim.Common.IModel model, Spatial.Point3D location)
        {
            if(location == null || model == null)
            {
                return null;
            }

            IfcAxis2Placement3D result = model.Instances.New<IfcAxis2Placement3D>();
            result.Location = location.ToIFC(model);

            return result;
        }
    }
}