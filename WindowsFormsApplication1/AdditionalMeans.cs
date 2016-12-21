using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    [Serializable]
    public class AdditionalMean
    {
        #region fields

        string _name;//имя
        bool _isBool;//булевое дополнение
        public bool boolValue;//если булевое, тогда берется значение - добавлять или нет
        int _maximumIntValue;//максимальное количество вариантов, в случе если дополнение не булевое, а имеет несколько вариантов
        int _intValue;//какой вариант из всех возможных у данного экземпляра
        int _place;//место в тексте клише
        bool _multiplicated;//переводится ли текст во множественное число
        string _text;//текст один, если значение булевое(он есть или его нет)
        string _multiText;//мультипликатор текста если он один
        string[] _texts;//варианты текста, если несколько вариантов дополнения
        string[] _multiTexts;//мультипликаторы для множественных вариантов текста
        public bool multi;//возвращать мультиплицированное значение текста, или нет

        #endregion

        #region properties
      

        public int intValue
        {
            get
            {
                if (!_isBool) return _intValue;
                else return 0;
            }
            set {
                if (value <= _maximumIntValue) _intValue = value;
               
            }

        }

        public string name
        {
            get {
                return _name;
            }
        }
        /// <summary>
        /// Место дополнительного текста в общем тексте клише:
        /// </summary>
        public int place
        {
            get { return _place; }
        }


        #endregion

        #region constructors

        /// <summary>
        /// Конструктор дополнения с вариантами, мультиплицируемого.
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="inMaximumValue"></param>
        /// <param name="inPlace"></param>
        /// <param name="inText"></param>
        /// <param name="inMultiText"></param>
        public AdditionalMean(string inName, int inMaximumValue, int inPlace, string[] inText, string[] inMultiText)
        {
            _name = inName;
            _isBool = false;
            _maximumIntValue = inMaximumValue;
            _place = inPlace;
            _multiplicated = true;
            _texts = inText;
            _multiTexts = inMultiText;

        }
        /// <summary>
        /// Конструктор дополнения с вариантами, не мультиплицируемого.
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="inMaximumValue"></param>
        /// <param name="inPlace"></param>
        /// <param name="inText"></param>
        public AdditionalMean(string inName, int inMaximumValue, int inPlace, string[] inText)
        {
            _name = inName;
            _isBool = false;
            _maximumIntValue = inMaximumValue;
            _place = inPlace;
            _multiplicated = false;
            _texts = inText;
     
        }
        /// <summary>
        /// Булевый, мультиплицируемый
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="inPlace"></param>
        /// <param name="inText"></param>
        /// <param name="inMultiText"></param>
        public AdditionalMean(string inName, int inPlace, string inText,string inMultiText)
        {
            _name = inName;
            _isBool = true;
            _place = inPlace;
            _multiplicated = true;

            _text = inText;
            _multiText = inMultiText;

        }

        /// <summary>
        /// Булевый не мультиплицируемый
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="inPlace"></param>
        /// <param name="inText"></param>
        public AdditionalMean(string inName, int inPlace, string inText)
        {
            _name = inName;
            _isBool = true;
            _place = inPlace;
            _multiplicated = false;
            _text = inText;
            

        }
        #endregion

    }
}
