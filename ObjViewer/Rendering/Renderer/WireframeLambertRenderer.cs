﻿using System.Numerics;
using GraphicsPipeline;
using ObjViewer.Rendering.Rasterization;
using ObjViewer.Rendering.Shaders;
namespace ObjViewer.Rendering.Renderer;

public sealed class WireframeLambertRenderer : SimpleRenderer<LambertFragmentShader, BresenhamRasterizer>
{
    private static readonly Vector3 LightPosition = new(0, 2, 8);
    protected override void OnDraw(in Model model, in Camera camera, in IRenderTarget renderTarget)
    {
        base.OnDraw(model, camera, renderTarget);
        BackfaceCulling = false;
        
        FragmentShader.LightPosition = LightPosition;
    }
}
