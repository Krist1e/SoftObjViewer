﻿using System.Numerics;
using GraphicsPipeline.Components.Shaders.Phong;
namespace GraphicsPipeline.Components.Rasterization.Interpolation;

public sealed class PhongScanlineInterpolator : IScanlineInterpolator<PhongShaderInput>
{
    public PhongShaderInput Average(in PhongShaderInput v0, in PhongShaderInput v1, in PhongShaderInput v2) => new()
    {
        Position = (v0.Position + v1.Position + v2.Position) / 3,
        Normal = (v0.Normal + v1.Normal + v2.Normal) / 3,
        TextureCoordinates = (v0.TextureCoordinates + v1.TextureCoordinates + v2.TextureCoordinates) / 3
    };

    public PhongShaderInput Interpolate(in PhongShaderInput v0, in PhongShaderInput v1, float w0, float w1, float w, float amount) => new()
    {
        Position = Vector3.Lerp(v0.Position, v1.Position, amount),
        Normal = Vector3.Lerp(v0.Normal, v1.Normal, amount),
        TextureCoordinates = Vector2.Lerp(v0.TextureCoordinates * w0, v1.TextureCoordinates * w1, amount) / w,
        Tangent = Vector3.Lerp(v0.Tangent, v1.Tangent, amount),
        Bitangent = Vector3.Lerp(v0.Bitangent, v1.Bitangent, amount)
    };
}