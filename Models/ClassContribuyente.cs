using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace adm_impuestos.Models
{
    public class Contribuyente
    {
        [Key] // Especifica que este campo es la clave primaria
        public int CodContrib { get; set; }
        public int? CodPersona { get; set; }
        public int? CodtipoContrib { get; set; }
        public DateTime? FecReg { get; set; }
        public DateTime? FecCierre { get; set; }

        // La propiedad NumCamaraComer ahora es nullable
        public string? NumCamaraComer { get; set; }

        public string? Status { get; set; }

        // Relaciones
        [ForeignKey("CodPersona")]
        public Persona? Persona { get; set; }

        [ForeignKey("CodtipoContrib")]
        public Tipo_Contribuyente? TipoContribuyente { get; set; }

        public ICollection<EventoContribuyente>? EventosContribuyente { get; set; }
    }

    public class EventoContribuyente
    {
        //[Key] // Especifica que este campo es la clave primaria
        public int CodContrib { get; set; }
        public string? NcfUsado { get; set; }
        public decimal? MontoNeto { get; set; }
        public decimal? Itbis { get; set; }
        public decimal? PorItbis { get; set; }
        public DateTime? Feccarga { get; set; }

        // Relación
        public Contribuyente? Contribuyente { get; set; }
    }

    public class Persona
    {
        [Key] // Especifica que este campo es la clave primaria
        public int CodPersona { get; set; }
        public string? PNom { get; set; }
        public string? SNom { get; set; }
        public string? PApe { get; set; }
        public string? SApe { get; set; }
        public string? RazonSocial { get; set; }
        public string? TipoIdent { get; set; }
        public string? DocumentoIdent { get; set; }
        public string? Sexo { get; set; }
        public DateTime? FecNac { get; set; }
        public string? Status { get; set; }
    }

    public class SerieNcf
    {
        [Key] // Especifica que este campo es la clave primaria
        public string? Serie { get; set; }
        public string? DescripSerie { get; set; }
        public string? AplicaFactElect { get; set; }
        public string? Status { get; set; }
    }

    public class VersionNcf
    {
        [Key] // Especifica que este campo es la clave primaria
        public int CodVersion { get; set; }
        public DateTime? Fecini { get; set; }
        public string? Desccripcion { get; set; }
        public DateTime? Fecfin { get; set; }
        public string? Status { get; set; }
    }

    public class Tipo_Ncf
    {
        //[Key] // Especifica que este campo es la clave primaria
        public string? TipoNcf { get; set; }
        public string? Serie { get; set; }
        public int CodVersion { get; set; }
        public string? DescripTiponcf { get; set; }
        public int LongSecuencia { get; set; }
        public string? Status { get; set; }

        // Relaciones
        [ForeignKey("Serie")]
        public SerieNcf? SerieNcf { get; set; }

        [ForeignKey("CodVersion")]
        public VersionNcf? VersionNcf { get; set; }
    }

    public class SecuenciaNcf
    {
        [Key] // Especifica que este campo es la clave primaria
        public int CodSec { get; set; }
        public string? TipoNcf { get; set; }
        public string? Serie { get; set; }
        public int? CodVersion { get; set; }
        public long? SecIni { get; set; }
        public long? SecFin { get; set; }
        public int? CantNum { get; set; }
        public DateTime? Fecreg { get; set; }
        public string? Status { get; set; }

        // Relaciones
        [ForeignKey("TipoNcf, Serie, CodVersion")] // Definiendo la relación con Tipo_Ncf
        public Tipo_Ncf? Tipo_Ncf { get; set; }

        // Relaciones
        /*[ForeignKey("TipoNcf")]
        public Tipo_Ncf? Tipo_Ncf { get; set; }

        [ForeignKey("Serie")]
        public SerieNcf? SerieNcf { get; set; }

        [ForeignKey("CodVersion")]
        public VersionNcf? VersionNcf { get; set; }*/
    }

    public class Tipo_Contribuyente
    {
        [Key] // Especifica que este campo es la clave primaria
        public int CodtipoContrib { get; set; }
        public string? TipoContribuyente { get; set; }
        public DateTime? FecReg { get; set; }
        public string? Status { get; set; }
    }

    public class Tipo_Identificacion
    {
        [Key] // Especifica que este campo es la clave primaria
        public string? TipoIdent { get; set; }
        public string? DescripcionTipoIdent { get; set; }
        public string? Status { get; set; }
    }
}
