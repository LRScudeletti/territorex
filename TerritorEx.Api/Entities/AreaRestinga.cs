﻿using System.ComponentModel;
using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

[Description("schema_area_restinga")]
public class AreaRestinga
{
    [Key]
    [Description("schema_area_id")]
    public int AreaId { get; set; }

    [Description("schema_territorio_id")]
    public int TerritorioId { get; set; }

    [Description("schema_sicar_id")]
    public int SicarId { get; set; }

    [Description("schema_descricao")]
    public string Descricao { get; set; }

    [Description("schema_area_hectare")]
    public double AreaHectare { get; set; }

    [Description("schema_shape")]
    public byte[] Shape { get; set; }

    [JsonIgnore]
    [Description("schema_usuario_atualizacao")]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    [Description("schema_data_atualizacao")]
    public DateTime DataAtualizacao { get; set; }
}