using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    [Serializable]
    public class Materials
    {
        string nameOfMaterial;
        public bool lightCured;
        public bool healable;
        public bool isolation;
        public bool flowable;
         bool isColorable;
        public List<string> colors = new List<string>();

        public bool colorable
        {
            get
            {
                if (colors.Count > 0) return true;
                else return false;
            }
            set {
                isColorable = value;
            }
        }
        public bool AddColor(string col)
        {
            if (colorsList.Contains(col)) return false;
            else colorsList.Add(col);
            return true;

        }
        public bool RemoveColor(string col)
        {
            if (colorsList.Contains(col))
            {
                colorsList.Remove(col);
                return true;
            }
            else return false;
        }
        public List<string> colorsList
        {
            get
            {
                return colors;
            }
            set
            {
                colors = value;
            }
        }
        public Materials()
        {

        }
        /// <summary>
        /// Конструктор с одним параметром Имя - создает материал с заданным именем, все остальные параметры False.
        /// </summary>
        /// <param name="nameOf"> Имя материала.</param>
        public Materials(string nameOf)
        {
            nameOfMaterial = nameOf;
            healable = false;
            isolation = false;
            flowable = false;
            colorable = false;
            lightCured = false;

        }
        /// <summary>
        /// Конструктор с двумя параметрами - Имя, и световой или нет композит, остальные параметры - False.
        /// </summary>
        /// <param name="nameOf">Имя композита</param>
        /// <param name="lightCure">Светоотверждаемый композит</param>
        public Materials(string nameOf, bool lightCure)
        {
            nameOfMaterial = nameOf;
            healable = false;
            isolation = false;
            flowable = false;
            colorable = false;
            lightCured = lightCure;

        }
        /// <summary>
        /// Конструктор создает световой материал заданного Имени, с заданной цветовой шкалой (в виде массива String).
        /// </summary>
        /// <param name="nameOf">Имя композита</param>
        /// <param name="palette">Оттенки - массив String</param>
        public Materials(string nameOf, string[] palette)
        {
            nameOfMaterial = nameOf;
            healable = false;
            isolation = false;
            flowable = false;
            lightCured = true;
            foreach (string col in palette)
            {
                colors.Add(col);
            }
        }
   /// <summary>
        /// Создает светоотверждаемый материал, с заданным Именем, заданной шкалой цветов(в виде массива строк), с параметром жидкотекучий
        /// </summary>
        /// <param name="nameOf">Имя материала</param>
        /// <param name="palette">Оттенки - массив String</param>
        /// <param name="isFlow">Жидкотекучий композит</param>
        public Materials(string nameOf, string[] palette, bool isFlow)
        {
            nameOfMaterial = nameOf;
            flowable = isFlow;
            healable = false;
            isolation = false;
            lightCured = true;
            foreach (string col in palette)
            {
                colors.Add(col);
            }
        }
        /// <summary>
        /// Конструктор создает материал химического отверждения, заданного Имени, с параметрами - жидкотекучий, лечебная подкладка
        /// </summary>
        /// <param name="nameOf">Имя</param>
        /// <param name="isFlow">Жидкотекучий</param>
        /// <param name="heal">Лечебная подкладка</param>
        public Materials(string nameOf, bool isFlow, bool heal)
        {
            nameOfMaterial = nameOf;
            flowable = isFlow;
            healable = heal;
            isolation = false;
            colorable = false;
            lightCured = false;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOf"></param>
        /// <param name="isFlow"></param>
        /// <param name="heal"></param>
        /// <param name="isolate"></param>
        public Materials(string nameOf, bool isFlow, bool heal, bool isolate)
        {
            nameOfMaterial = nameOf;
            flowable = isFlow;
            healable = heal;
            isolation = isolate;
            colorable = false;
            lightCured = false;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOf"></param>
        /// <param name="isFlow"></param>
        /// <param name="heal"></param>
        /// <param name="isolate"></param>
        /// <param name="lightCure"></param>
        public Materials(string nameOf, bool isFlow, bool heal, bool isolate, bool lightCure)
        {
            nameOfMaterial = nameOf;
            flowable = isFlow;
            healable = heal;
            isolation = isolate;
            colorable = false;
            lightCured = lightCure;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOf"></param>
        /// <param name="isFlow"></param>
        /// <param name="heal"></param>
        /// <param name="isolate"></param>
        /// <param name="palette"></param>
        public Materials(string nameOf, bool isFlow, bool heal, bool isolate, string[] palette)
        {
            nameOfMaterial = nameOf;
            flowable = isFlow;
            healable = heal;
            isolation = isolate;
            colorable = true;
            foreach (string col in palette)
            {
                colors.Add(col);
            }
        }

        public Materials(Materials copyMat)
        {
            this.Copy(copyMat);
        }
        public string Name
        {
            get
            {
                if (nameOfMaterial == null) return "N/A";
                else return nameOfMaterial;
            }
            set
            {
                if (value != null) nameOfMaterial = value;
                else nameOfMaterial = "N/A";
            }
        }

        public void Copy(Materials matToCopy)
        {
            nameOfMaterial = matToCopy.nameOfMaterial;
            lightCured = matToCopy.lightCured;
            healable = matToCopy.healable;
            isolation = matToCopy.isolation;
            flowable = matToCopy.flowable;
            colorable = matToCopy.colorable;
            this.CopyColor(matToCopy.colors, true);
        }

        public void CopyColor(List<string> colorToCopy, bool clearListBefore)
        {
            if (clearListBefore) colorsList.Clear();
            foreach (string col in colorToCopy)
            {
                colorsList.Add(col);
            }
        }


    }
}
