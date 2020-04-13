using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Projekat.Models
{
    /// <summary>
    /// Material class
    /// </summary>
    public class MaterijalModel
    {
        /// <summary>
        /// Gets or sets the materijal identifier.
        /// </summary>
        /// <value>
        /// The materijal identifier.
        /// </value>
        [Key]
        public int materijalId { get; set; }

        /// <summary>
        /// Gets or sets the materijal file.
        /// </summary>
        /// <value>
        /// The materijal file.
        /// </value>
        [DisplayName("Materijal")]
        [MaxLength]
        public byte[] materijalFile { get; set; }

        /// <summary>
        /// Gets or sets the type of the file MIME.
        /// </summary>
        /// <value>
        /// The type of the file MIME.
        /// </value>
        [HiddenInput(DisplayValue = false)]
        public string fileMimeType { get; set; }

        //[DataType(DataType.MultilineText)]
        /// <summary>
        /// Gets or sets the materijal description.
        /// </summary>
        /// <value>
        /// The materijal description.
        /// </value>
        public string materijalOpis { get; set; }

        public DateTime datumMaterijali { get; set; }

        //[DataType(DataType.DateTime)]
        //[DisplayName("Created Date")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        //public DateTime CreatedDate { get; set; }

        //public string UserName { get; set; }
        //   public PredmetModel Predmet { get; set; }

        //  public int predmetId { get; set; }

        /// <summary>
        /// Gets or sets the materijal extension.
        /// </summary>
        /// <value>
        /// The materijal extension.
        /// </value>
        public string materijalEkstenzija { get; set; }

        /// <summary>
        /// Gets or sets the materijal name.
        /// </summary>
        /// <value>
        /// The materijal name.
        /// </value>
        public string materijalNaziv { get; set; }

        /// <summary>
        /// Gets or sets the materijal heading.
        /// </summary>
        /// <value>
        /// The materijal heading.
        /// </value>
        public string materijalNaslov { get; set; }

        public string idUser { get; set; }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        public string ImgPath
        {
            get
            {
                if (this.materijalEkstenzija == ".pdf")
                    return "~/Content/img/PDFicon.png";
                else if (this.materijalEkstenzija == ".rar")
                    return "~/Content/img/RARicon.png";
                else if (this.materijalEkstenzija == ".txt")
                    return "~/Content/img/TXTicon.png";
                else if (this.materijalEkstenzija == ".jpg")
                    return "~/Content/img/JPGicon.png";
                else if (this.materijalEkstenzija == ".gif")
                    return "~/Content/img/GIFicon.png";
                else if (this.materijalEkstenzija == ".png")
                    return "~/Content/img/PNGicon.png";
                else if (this.materijalEkstenzija == ".zip")
                    return "~/Content/img/ZIPicon.png";
                else if (this.materijalEkstenzija == ".rtf")
                    return "~/Content/img/RTFicon.png";
                else if (this.materijalEkstenzija == ".mp4")
                    return "~/Content/img/MP4icon.png";
                else return "Err";
            }
        }

        /// <summary>
        /// Gets or sets the modul model.
        /// </summary>
        /// <value>
        /// The modul model.
        /// </value>
        public ModulModel ModulModel { get; set; }

        /// <summary>
        /// Gets or sets the modul identifier.
        /// </summary>
        /// <value>
        /// The modul identifier.
        /// </value>
        [ForeignKey("ModulModel")]
        public int? modulId { get; set; }

        /// <summary>
        /// Gets or sets the predmet model.
        /// </summary>
        /// <value>
        /// The predmet model.
        /// </value>
        public PredmetModel PredmetModel { get; set; }

        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        [ForeignKey("PredmetModel")]
        public int? predmetId { get; set; }

        /// <summary>
        /// Gets or sets the tip materijal model.
        /// </summary>
        /// <value>
        /// The tip materijal model.
        /// </value>
        public TipMaterijalModel TipMaterijalModel { get; set; }

        public string odobreno { get; set; }
        public string obrazlozenje { get; set; }

        /// <summary>
        /// Gets or sets the tip materijal identifier.
        /// </summary>
        /// <value>
        /// The tip materijal identifier.
        /// </value>
        [ForeignKey("TipMaterijalModel")]
        public int tipMaterijalId { get; set; }

        /// <summary>
        /// Gets or sets the namena materijala model.
        /// </summary>
        /// <value>
        /// The namena materijala model.
        /// </value>
        public NamenaMaterijalaModel NamenaMaterijalaModel { get; set; }

        /// <summary>
        /// Gets or sets the namena materijala identifier.
        /// </summary>
        /// <value>
        /// The namena materijala identifier.
        /// </value>
        [ForeignKey("NamenaMaterijalaModel")]
        public int namenaMaterijalaId { get; set; }
    }
}