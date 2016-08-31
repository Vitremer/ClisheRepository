using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace KlisheNamespace
{
     class KlisheParams //класс параметров программы - в нем хранятся блоки в виде словаря из которых собираются клише 
     {
         #region Fields
         static bool isFlowable = true;
        static bool isHealable = true;
        static bool isIsolation = true;
        public static List<Anesthetics> anesteticsList = new List<Anesthetics>();
        public static List<Anesthetics> applicationList = new List<Anesthetics>();
         public static   List<Materials> mainMatList = new List<Materials>();
         public static List<Diagnos> defaultDiagnosList = new List<Diagnos>();
         public static List<Condition> conditionOfFaceList = new List<Condition>();
       static Dictionary<string, string> blocksDictionary = new Dictionary<string, string>();//словарь блоков для клише
       static  string path = Path.Combine(Environment.CurrentDirectory, "blocksData.bin");
        static string path2anest = Path.Combine(Environment.CurrentDirectory, "anestetics.bin");
        static string path2diag = Path.Combine(Environment.CurrentDirectory, "diagnosis.bin");
       static  string path2appl = Path.Combine(Environment.CurrentDirectory, "applicateAnest.bin");
        static string path2matAdminDefault = Path.Combine(Environment.CurrentDirectory, "materialsAdminSource.bin");
        static string path2matDefault = Path.Combine(Environment.CurrentDirectory, "materials.bin");
        static string path2matCurrent = Path.Combine(Environment.CurrentDirectory, "materialsCurrent.bin");
        static string path2conditionList = Path.Combine(Environment.CurrentDirectory, "conditionsOfFace.bin");

#endregion

        public static List<Materials> mainMaterialList
        {
            get { return mainMatList; }

        }


          static KlisheParams()
        {

            #region BlocksDictionaryLoading
            try//попробовать прочитать словарь блоков из сохраненных
            {

                blocksDictionary = Read(path);
            }
            catch //если словаря нет - загружаем по умолчанию новый
            {

                blocksDictionary.Add("jaloby_Кариес_pov", " на наличие кариозного пятна, быстропроходящую реакцию на сладкое,");
                blocksDictionary.Add("jaloby_Кариес", " на кратковременные боли от механических, химических, температурных  раздражителей, попадание пищи,  наличие  полости");
                blocksDictionary.Add("jaloby_Пломба с нарушением", " на неудовлетворительный внешний вид пломбы, потемнение и разрушенность пломбы, ");

                blocksDictionary.Add("jaloby_Несостоятельный контакт", " на застревание пищи, постоянную кровоточивость десны между зубами ");
                blocksDictionary.Add("jaloby_Клиновидный дефект", "на боли от холодного, сладкого, кислого, неприятные ощущения при чистке зубов , наличие дефекта твердых тканей около десны");


                //устаревший код
                blocksDictionary.Add("jaloby_plombCont", " на застревание пищи, постоянную кровоточивость десны между зубами, неудовлетворительный внешний вид пломбы");
                blocksDictionary.Add("jaloby_carCont", " на кратковременные боли от механических, химических, температурных  раздражителей, попадание пищи,  наличие  полости");                
                blocksDictionary.Add("jaloby_plomb", " на неудовлетворительный внешний вид пломбы, потемнение пломбы");
                blocksDictionary.Add("jaloby_defect", " на скол зуба, на застревание пищи, острые края, травмирующие слизистую щеки, язык, кратковременные боли от температурных раздражителей");
              
                blocksDictionary.Add("jaloby_pov_povcar_info", " Текст блока с жалобами при поверхностном кариесе.");
                blocksDictionary.Add("jaloby_sred_car_info", " Текст блока с жалобами при среднем кариесе.");
                blocksDictionary.Add("jaloby_glub_car_info", " Текст блока с жалобами при глубоком кариесе.");
                blocksDictionary.Add("jaloby_giper_car_info", " Текст блока с жалобами при кариесе - гиперемия пульпы.");
                blocksDictionary.Add("jaloby_contact_info", " Текст блока с жалобами при несостоятельном контакте.");
              //

                blocksDictionary.Add("jaloby_zubOne", " в области зуба ");
                blocksDictionary.Add("jaloby_zubMany", " в области зубов ");

                #region Anamnes TextBlocks //Блоки текста для анамнеза
                blocksDictionary.Add("anamnes_pretreat_0", " - ранее не лечен, ");
                blocksDictionary.Add("anamnes_pretreat_1", " - ранее  лечен по поводу неосложненного кариеса, ");
                blocksDictionary.Add("anamnes_pretreat_2", " - ранее лечен по поводу осложненного кариеса, ");
                blocksDictionary.Add("anamnes_trouble_hronFibrPulp"," - ранее реагировал на температурные раздражители, были самопроизвольные боли");
                blocksDictionary.Add("anamnes_trouble_multi_hronFibrPulp", "реагировал_реагировали");
               
                blocksDictionary.Add("anamnes_trouble_hronibrPulpObostr"," - боли беспокоят в течение недели. Ранее была острая боль в зубе самопроизвольного характера");
                blocksDictionary.Add("anamnes_trouble_multi_hronFibrPulpObostr", "зубе_зубах");
                
                //Кариес поверхностный.
                blocksDictionary.Add("anamnes_trouble_03", " беспокоит в течение месяца");
                blocksDictionary.Add("anamnes_trouble_multi_03", "беспокоит_беспокоят");
                //Остальные кариесы
                blocksDictionary.Add("anamnes_trouble_0", " беспокоит в течение месяца");
                blocksDictionary.Add("anamnes_trouble_multi_0", "беспокоит_беспокоят");

                blocksDictionary.Add("anamnes_trouble_contact", " беспокоит в течение месяца");
                blocksDictionary.Add("anamnes_trouble_multi_contact", "беспокоит_беспокоят");

                blocksDictionary.Add("anamnes_trouble_20", " дефект начал появляться в течение года, реагирует в течение месяца");
                blocksDictionary.Add("anamnes_trouble_multi_20", "дефект начал появлятся в течение года, реагирует в течение месяца_дефекты начали появлятся в течение года, реагируют в течение месяца");
                //
                #endregion


                blocksDictionary.Add("face_name_distal", "дистальн");
                blocksDictionary.Add("face_name_medial", "медиальн");
                blocksDictionary.Add("face_name_palatinal", "нёбн");
                blocksDictionary.Add("face_name_okklusion", "окклюзионн");
                blocksDictionary.Add("face_name_vestibular", "вестибулярн");
                blocksDictionary.Add("face_name_lingual", "язычн");
                blocksDictionary.Add("face_name_edge", "режущий край");

                
                blocksDictionary.Add("face_name_edge_onthe", "режущему краю");





                blocksDictionary.Add("objectivno_connected", "сообщающиеся между собой");

                
                blocksDictionary.Add("objectivno_carpolost","кариозная полость");
                blocksDictionary.Add("objectivno_carpolostis","кариозные полости");
                  blocksDictionary.Add("objectivno_glubcarpolost", "глубокая кариозная полость");
                blocksDictionary.Add("objectivno_glubcarpolostis", "глубокие кариозные полости");
                blocksDictionary.Add("objectivno_polost_multi", "кариозная полость_кариозные полости");
                blocksDictionary.Add("objectivno_glubpolost_multi", "глубокая кариозная полость_глубокие кариозные полости");
                 
                blocksDictionary.Add("objectivno_cavern_giper_car", " в пределах околопульпарного дентина с пологими краями и широким входным отверстием, сообщается с полостью зуба в одной точке");
                  blocksDictionary.Add("objectivno_cavern_glub_car", " в пределах околопульпарного дентина с пологими краями и широким входным отверстием");
                 blocksDictionary.Add("objectivno_cavern_sred_car", " в пределах плащевого  дентина, заполненная размягченным , пигментированным дентином");
                 blocksDictionary.Add("objectivno_cavern_pov_car", " в пределах эмали");

                 blocksDictionary.Add("objectivno_mukosapapil", "Слизистая ");
                blocksDictionary.Add("objectivno_textpapil", " межзубного сосочка гиперемирована, отечна, кровоточит при зондировании. ");
                 blocksDictionary.Add("objectivno_distpapil", " дистального ");
                 blocksDictionary.Add("objectivno_medpapil", " медиального ");
                 blocksDictionary.Add("objectivno_papil_multi", "межзубного_межзубных|сосочка_сосочков");

                 blocksDictionary.Add("objectivno_percus_0", "Перкуссия безболезненная. ");
                 blocksDictionary.Add("objectivno_percus_1", "Перкуссия слабоболезненная. ");
                 blocksDictionary.Add("objectivno_percus_2", "Перкуссия болезненная. ");

                 blocksDictionary.Add("objectivno_ruin_0", "");
                 blocksDictionary.Add("objectivno_ruin_1", " Зуб разрушен до 1/2. ");
                 blocksDictionary.Add("objectivno_ruin_2", " Зуб разрушен более чем на 1/2. ");

                 blocksDictionary.Add("objectivno_mucosa_0", "");
                 blocksDictionary.Add("objectivno_mucosa_1", " Слизистая маргинальной десны незначительно гиперемирована, отека нет.");
                 blocksDictionary.Add("objectivno_mucosa_2", " Слизистая маргинальной десны гиперемирована, отека нет");
                 blocksDictionary.Add("objectivno_mucosa_3", " Слизистая маргинальной десны гиперемирована, отечна, кровоточит при зондировании. ");
                 blocksDictionary.Add("objectivno_mucosa_4", " Слизистая маргинальной десны гиперемирована, отечна, разрыхлена, гипертрофирована, кровоточит при зондировании. ");


                 blocksDictionary.Add("objectivno_otek_0", " Слизистая переходной складки бледно-розовая, гладкая, блестящая.");
                 blocksDictionary.Add("objectivno_otek_1", " Слизистая переходной складки незначительно гиперемирована, отека нет. ");
                 blocksDictionary.Add("objectivno_otek_2", " Слизистая переходной складки гиперемирована, отека нет. ");
                 blocksDictionary.Add("objectivno_otek_3", " Слизистая переходной складки гиперемирована,  ");
                 blocksDictionary.Add("objectivno_otek_4", " Зуб разрушен более чем на 1/2. ");


                blocksDictionary.Add("objectivno_termotest_0", "Температурная проба на холодовой раздражитель отрицательная.  ");
                 blocksDictionary.Add("objectivno_termotest_1", "Температурная проба на холодовой раздражитель кратковременная.  ");
                 blocksDictionary.Add("objectivno_termotest_2", "Температурная проба на холодовой раздражитель положительная, сохраняющаяся долгое время после устранения раздражителя.  ");

                blocksDictionary.Add("objectivno_plomb", "пломба");
                blocksDictionary.Add("objectivno_plomb_big", "обширная пломба");
                blocksDictionary.Add("objectivno_plomb_more_half", "обширная пломба занимает более 1/2 коронковой части зуба");
                blocksDictionary.Add("objectivno_plomb_multi", "пломба_пломбы");

                blocksDictionary.Add("objectivno_plomb_color", "изменена в цвете");
              

                blocksDictionary.Add("objectivno_with_viol", "с нарушением");
                blocksDictionary.Add("objectivno_without_viol", "без нарушения");
                 blocksDictionary.Add("objectivno_Средний кариес", "кариозная полость в пределах плащевого дентина");
             
                blocksDictionary.Add("objectivno_plomb_anatomy_def", "анатомической формы зуба");
                blocksDictionary.Add("objectivno_contact", "контактного пункта");
                blocksDictionary.Add("objectivno_plomb_def", "краевого прилегания");

                blocksDictionary.Add("objectivno_ne_vskrita", "Полость зуба не вскрыта.");
                blocksDictionary.Add("objectivno_vskrita", "Полость зуба вскрыта в одной точке - пульпа жизнеспособна, незначительно кровоточит.");
               
                blocksDictionary.Add("objectivno_zondir", "Зондирование болезненное ");

                blocksDictionary.Add("objectivno_zondir_giper", "в точке сообщения с полостью.");
                blocksDictionary.Add("objectivno_zondir_glub", "по всему дну полости, дно плотное пигментированное.");
                blocksDictionary.Add("objectivno_zondir_sred", "по эмалево-дентинной границе.");
                blocksDictionary.Add("objectivno_zondir_pov", "по поверхности полости.");


                blocksDictionary.Add("rvg_clean", ", корневые каналы не запломбированы, изменений в периодонте не визуализируется.");


                blocksDictionary.Add("treatment_local_anest", "под местной ");
                blocksDictionary.Add("treatment_anest", "анестезией ");
                blocksDictionary.Add("treatment_intraligamental_anest", "интралигаментарной ");
                blocksDictionary.Add("treatment_intrapulpar_anest", "внутрипульпарной ");
                blocksDictionary.Add("treatment_intraseptal_anest", "интрасептальной ");
                blocksDictionary.Add("treatment_application_anest", "аппликационной ");
                blocksDictionary.Add("treatment_infiltration_anest", "инфильтрационной ");
                blocksDictionary.Add("treatment_conduction_anest", "проводниковой ");
                blocksDictionary.Add("treatment_inregion", " в области ");

                blocksDictionary.Add("treatment_condition", " чистка зуба циркулярной щеточкой с пастой детартрин, ");
                blocksDictionary.Add("treatment_condition_multi", "зуба_зубов");

                blocksDictionary.Add("treatment_prep", "  механическая обработка кариозной полости по ");
                blocksDictionary.Add("treatment_prep_multi", "кариозной полости_кариозных полостей");

                blocksDictionary.Add("treatment_med_cav", " медикаментозная обработка полости раствором хлоргексидина 2%, ");
                blocksDictionary.Add("treatment_med_cav_multi", "полости_полостей");

                blocksDictionary.Add("treatment_shlif", "Шлифовка, полировка пломбы. ");
                blocksDictionary.Add("treatment_shlif_multi", "пломбы_пломб");

                blocksDictionary.Add("treatment_ftor", " Покрытие фторлаком.");
                blocksDictionary.Add("treatment_remind", " Выдана памятка для пациента о правилах поведения после лечения зубов. Явка по записи.");
               








                

                blocksDictionary.Add("kvadrant0", " ??? челюсти ??? ");
                blocksDictionary.Add("kvadrant1", " верхней челюсти справа ");
                blocksDictionary.Add("kvadrant2", " верхней челюсти слева ");
                blocksDictionary.Add("kvadrant3", " нижней челюсти слева ");
                blocksDictionary.Add("kvadrant4", " нижней челюсти справа ");
                Write(blocksDictionary, path);





            }
            #endregion
            #region Anestetics List Creation
            try
            {
                anesteticsList = ReadFromBinaryFile<List<Anesthetics>>(path2anest);
            }
            catch
            {
                anesteticsList = CreateDefaultAnesteticsList();
                WriteToBinaryFile<List<Anesthetics>>(path2anest, anesteticsList, false);
            }
            #endregion
            #region ApplicationAnestesy List Creation
            try
            {
                applicationList = ReadFromBinaryFile<List<Anesthetics>>(path2appl);
            }
            catch
            {
                applicationList = CreateDefaultApplicateAnestList();
                WriteToBinaryFile<List<Anesthetics>>(path2appl, applicationList, false);
            }
            #endregion
            #region MaterialList Creation
            try
            {
                mainMatList = ReadFromBinaryFile<List<Materials>>(path2matCurrent);
            }
            catch
            {
                try
                {
                    mainMatList = ReadFromBinaryFile<List<Materials>>(path2matDefault);
                }
                catch
                {
                    try
                    {
                        mainMatList = ReadFromBinaryFile<List<Materials>>(path2matAdminDefault);
                    }
                    catch
                    {
                        CreateDefaultMaterialList();
                        WriteToBinaryFile<List<Materials>>(path2matCurrent, mainMaterialList, false);
            

                        WriteToBinaryFile<List<Materials>>(path2matDefault, mainMaterialList, false);
                     

                        WriteToBinaryFile<List<Materials>>(path2matAdminDefault, mainMaterialList, false);
                        System.IO.File.SetAttributes(path2matAdminDefault, System.IO.FileAttributes.Hidden);
                        System.IO.File.SetAttributes(path2matAdminDefault, System.IO.FileAttributes.ReadOnly);


                    }
                }
            }
            #endregion
            #region ConditionList Creation

            try
            {
                conditionOfFaceList = ReadFromBinaryFile<List<Condition>>(path2conditionList);
            }
            catch
            {
                conditionOfFaceList = CreateDefaultConditionsList();
                WriteToBinaryFile<List<Condition>>(path2conditionList, conditionOfFaceList, false);
            }

            #endregion

            #region DiagnosList Creation

            try
            {
                defaultDiagnosList = ReadFromBinaryFile<List<Diagnos>>(path2diag);
            }
            catch
            {
                defaultDiagnosList = CreateDefaultDiagnosList();
                WriteToBinaryFile<List<Diagnos>>(path2diag, defaultDiagnosList, false);
            }

            #endregion

        }


          #region Creating Default Lists

          static List<Diagnos> CreateDefaultDiagnosList()
          {
              List<Diagnos> diagList = new List<Diagnos>();
              diagList.Add(new Diagnos("Глубокий кариес, (К02.1)",0,1,new string[]{"Кариес"}, new List<Type>{ typeof(Tooth)}, new List<DentistrySection.Section>{ DentistrySection.Section.terapy,DentistrySection.Section.child_terapy,DentistrySection.Section.ortopedics,DentistrySection.Section.child_ortopedics,DentistrySection.Section.surgery,DentistrySection.Section.child_surgery} ));
              diagList.Add(new Diagnos("Средний кариес, (К02.1)",0,2, new string[]{"Кариес"},new List<Type> { typeof(Tooth) }, new List<DentistrySection.Section> { DentistrySection.Section.terapy, DentistrySection.Section.child_terapy, DentistrySection.Section.ortopedics, DentistrySection.Section.child_ortopedics, DentistrySection.Section.surgery, DentistrySection.Section.child_surgery }));
              diagList.Add(new Diagnos("Поверхностный кариес, (К02.1)", 0, 3,new string[]{"Кариес"},new List<Type> { typeof(Tooth) }, new List<DentistrySection.Section> { DentistrySection.Section.terapy, DentistrySection.Section.child_terapy, DentistrySection.Section.ortopedics, DentistrySection.Section.child_ortopedics, DentistrySection.Section.surgery, DentistrySection.Section.child_surgery }));
              diagList.Add(new Diagnos("Кариес депульпированного зуба, (К02.8)", 1, 0,new string[]{"Пломба дефект"},new List<Type> { typeof(Tooth) }, new List<DentistrySection.Section> { DentistrySection.Section.terapy, DentistrySection.Section.child_terapy, DentistrySection.Section.ortopedics, DentistrySection.Section.child_ortopedics, DentistrySection.Section.surgery, DentistrySection.Section.child_surgery }));
              diagList.Add(new Diagnos("Клиновидный дефект", 2,0,new string[]{"Клиновидный дефект"},new List<Type> { typeof(Tooth) }, new List<DentistrySection.Section> { DentistrySection.Section.terapy, DentistrySection.Section.child_terapy, DentistrySection.Section.ortopedics, DentistrySection.Section.child_ortopedics, DentistrySection.Section.surgery, DentistrySection.Section.child_surgery }));
              diagList.Add(new Diagnos("Эрозия твердых тканей зуба",3, 0,new string[]{"Клиновидный дефект"},new List<Type> { typeof(Tooth) }, new List<DentistrySection.Section> { DentistrySection.Section.terapy, DentistrySection.Section.child_terapy, DentistrySection.Section.ortopedics, DentistrySection.Section.child_ortopedics, DentistrySection.Section.surgery, DentistrySection.Section.child_surgery }));
              diagList.Add(new Diagnos("Гиперемия пульпы", 0, 0,new string[] { "Клиновидный дефект" }, typeof(Tooth), DentistrySection.Section.terapy));

              return diagList;
          }
          static List<Anesthetics> CreateDefaultAnesteticsList()
          {
              List<Anesthetics> anList = new List<Anesthetics>();
              anList.Add(new Anesthetics("Ультракаин ДС 1:200000", 1));
              anList.Add(new Anesthetics("Ультракаин ДС Форте 1:100000", 2));
              anList.Add(new Anesthetics("Ультракаин Д", 0));
              anList.Add(new Anesthetics("Убистезин 1:200000", 1));
              anList.Add(new Anesthetics("Убистезин Форте 1:100000", 2));
              anList.Add(new Anesthetics("Септанест 1:200000", 1));
              anList.Add(new Anesthetics("Септанест 1:100000", 2));
              anList.Add(new Anesthetics("Скандонест", 0));
              return anList;



          }
          static List<Anesthetics> CreateDefaultApplicateAnestList()
          {
              List<Anesthetics> anList = new List<Anesthetics>();
              anList.Add(new Anesthetics("Лидоксор"));
              anList.Add(new Anesthetics("Дисилан +"));
              return anList;



          }

          public static Materials findMaterial(string nameOfMatToFind)
          {
              Materials findedMat = new Materials();
              foreach (Materials mat in mainMaterialList)
              {
                  if (mat.Name == nameOfMatToFind)
                  {
                      findedMat.Copy(mat);
                      break;
                  }

              }
              return findedMat;
          }

          static void CreateDefaultMaterialList()
          {


              mainMatList.Add(new Materials("Кальцимол", isFlowable, isHealable));
              mainMatList.Add(new Materials("Биодентин", !isFlowable, isHealable));
              mainMatList.Add(new Materials("ProRoot", isFlowable, isHealable));
              mainMatList.Add(new Materials("Биодентин пломба"));
              mainMatList.Add(new Materials("Кемфил", !isFlowable, !isHealable, isIsolation));
              mainMatList.Add(new Materials("Кемфил пломба"));
              mainMatList.Add(new Materials("Глассин", !isFlowable, !isHealable, isIsolation));
              mainMatList.Add(new Materials("Витремер", !isFlowable, !isHealable, isIsolation));
              mainMatList.Add(new Materials("SDR", isFlowable, !isHealable, isIsolation));
              mainMatList.Add(new Materials("Filtek Flow", isFlowable, !isHealable, isIsolation));
              mainMatList.Add(new Materials("Enamel Flow", isFlowable, !isHealable, isIsolation));
              mainMatList.Add(new Materials("Charisma", new string[] { "OA1", "OA2", "OA3", "A1", "A2", "A3", "C1", "C2", "C3", "B1", "B2", "B3", "I" }));
              mainMatList.Add(new Materials("Charisma Daimond", new string[] { "OL", "OM", "OD", "A1", "A2", "A3", "C1", "C2", "C3", "B1", "B2", "B3", "CL", "BL" }));
              mainMatList.Add(new Materials("T-econome", new string[] { "A1", "A2", "A3", "C1", "C2", "C3", "B1", "B2", "B3" }));
              mainMatList.Add(new Materials("Estelite", new string[] { "OA1", "OA2", "OA3", "A1", "A2", "A3", "C1", "C2", "C3", "B1", "B2", "B3", "CL", "WE" }));
              mainMatList.Add(new Materials("Filtek Z250", new string[] { "UD", "A1", "A2", "A3", "C1", "C2", "C3", "B1", "B2", "B3", "D1", "D2", "D3" }));
              mainMatList.Add(new Materials("Filtek Ultimate", new string[] { "dentin A1", "dentin A2", "dentin A3", "dentin B1", "dentin B2", "dentin B3", "body A1", "body A2", "body A3", "body A3.5", "enamel A1", "enamel A2", "enamel A3", "Translucent", "Transparent" }));
              mainMatList.Add(new Materials("Filtek Z550", new string[] { "dentin A1", "dentin A2", "dentin A3", "dentin B1", "dentin B2", "dentin B3", "body A1", "body A2", "body A3", "body A3.5", "enamel A1", "enamel A2", "enamel A3", "Translucent", "Transparent" }));
              mainMatList.Add(new Materials("Estet-X HD", new string[] { "A2-O", "A3-O", "A4-O", "B2-O", "B3-O", "C1-O", "C4-O", "D3-O", "U", "A1", "A2", "A3", "C1", "C2", "C3", "C4", "C5/XGB", "B1", "B2", "B3", "B5/DY", "AE", "YE", "CE", "GE", "WE", "XL", "WO", }));
              mainMatList.Add(new Materials("Enamel", new string[] { "UD0.5", "UD1", "UD2", "UD3", "UD4", "UD5", "UD6", "UE1", "UE2", "UE3", "FE1", "FE2", "FE3", "OBN", "OA", "IW", "IM", "B1", "B2", "B3", "D1", "D2", "D3" }));
              mainMatList.Add(new Materials("Компосайт", !isFlowable, !isHealable, !isIsolation));


          }

          static List<Condition> CreateDefaultConditionsList()
          {
              List<Condition> condiList = new List<Condition>();

              condiList.Add(new Condition(

                  "Кариес",
                  new List<Face.faceSide>() { Face.faceSide.all },

                  new Condition.DepthOfCondition[] { Condition.DepthOfCondition.pov, Condition.DepthOfCondition.sred, Condition.DepthOfCondition.glub, Condition.DepthOfCondition.giper },

                  new Dictionary<Condition.DepthOfCondition, int[]>(){
                    {   Condition.DepthOfCondition.pov,new int[2]{0,3}},
                    { Condition.DepthOfCondition.sred,new int[2]{0,2}},
                    {  Condition.DepthOfCondition.glub,new int[2]{0,1}},
                    { Condition.DepthOfCondition.giper,new int[2]{0,0}},
                  },

                  new Dictionary<Condition.DepthOfCondition, string>() { 
                  { Condition.DepthOfCondition.pov, "в пределах эмали, зондирование слабоболезненно по поверхности полости. " },
                  { Condition.DepthOfCondition.sred, "в пределах плащевого дентина заполненная размягченным , пигментированным дентином. Зондирование болезненно по эмалево-дентинному соединению. " },
                  { Condition.DepthOfCondition.glub, "в пределах околопульпарного дентина с пологими краями и широким входным отверстием. Полость зуба не вскрыта. На дне и стенках кариозной полости пигментированный, плотный дентин. Зондирование болезненно по всему дну полости.  " }, 
                  { Condition.DepthOfCondition.giper, "в пределах околопульпарного дентина, сообщается с полостью зуба в одной точке. Полость зуба  вскрыта в одной точке - пульпа жизнеспособна, незначительно кровоточит - кровоточивость купировалась самостоятельно. На дне и стенках кариозной полости пигментированный, плотный дентин. Зондирование болезненно в точке сообщения. " } },

                  "кариозная полость",

                    new Dictionary<Condition.DepthOfCondition, string>() { 
                  { Condition.DepthOfCondition.pov, "в пределах эмали, " },
                  { Condition.DepthOfCondition.sred, "в пределах плащевого дентина, " },
                  { Condition.DepthOfCondition.glub, "в пределах околопульпарного дентина, не сообщается с полостью зуба" }, 
                  { Condition.DepthOfCondition.giper, "в пределах околопульпарного дентина, близко располагается с полостью зуба" } },

                  "кариозная полость",

                  0, 2,
                  Color.Red,
                  "кариозная полость_кариозные полости|заполненная_заполненные|кариозной полости_кариозных полостей|полости_полостей|сообщается_сообщаются|кариозной полости_кариозных полостей",
                  new Dictionary<Condition.DepthOfCondition, List<Affiction>>()
                  {
                       {Condition.DepthOfCondition.pov,new  List<Affiction> (){new Affiction("eod",6),new Affiction("termotest",1)} },
                      {Condition.DepthOfCondition.sred,new  List<Affiction> (){new Affiction("eod",8),new Affiction("termotest",1)} },
                      {Condition.DepthOfCondition.glub,new  List<Affiction> (){new Affiction("eod",12),new Affiction("termotest",1)}  },
                      {Condition.DepthOfCondition.giper,new  List<Affiction> (){new Affiction("eod",15),new Affiction("termotest",2),new Affiction("polost",1)}  }
                  }
                  ));

              condiList.Add(new Condition("Пломба с нарушением",
                  new List<Face.faceSide>() { Face.faceSide.all },
                  new Condition.DepthOfCondition[] { Condition.DepthOfCondition.none },
                  new Dictionary<Condition.DepthOfCondition, string>(),
                  "пломба с нарушением краевого прилегания, после снятия пломбы - ",

                   new Dictionary<Condition.DepthOfCondition, string>(),

                  "пломба с нарушением краевого прилегания, ",

                  1, 1,
                  Color.Gray,
                  "пломба_пломбы|пломбы_пломб",
                   new Dictionary<Condition.DepthOfCondition, List<Affiction>>() {
                  {Condition.DepthOfCondition.none,new  List<Affiction> (){new Affiction("pretreat",1)} }
                  }
                  ));

              condiList.Add(new Condition("Пломба без нарушения",
                                new List<Face.faceSide>() { Face.faceSide.all },
                                new Condition.DepthOfCondition[] { Condition.DepthOfCondition.none },
                                new Dictionary<Condition.DepthOfCondition, string>(),
                                "пломба без нарушения краевого прилегания, ",
                                   new Dictionary<Condition.DepthOfCondition, string>(),
                                "пломба без нарушения краевого прилегания,  ",

                                4, 0,
                                Color.White,
                                 "пломба_пломбы",
                                  new Dictionary<Condition.DepthOfCondition, List<Affiction>>() {
                  {Condition.DepthOfCondition.none,new  List<Affiction> (){new Affiction("pretreat",1)} }
                  }
                  ));


              condiList.Add(new Condition("Клиновидный дефект",
                  new List<Face.faceSide>() { Face.faceSide.vestibular },

                  new Condition.DepthOfCondition[] { Condition.DepthOfCondition.pov, Condition.DepthOfCondition.sred, Condition.DepthOfCondition.glub, Condition.DepthOfCondition.giper },
                   
                  new Dictionary<Condition.DepthOfCondition, int[]>(){
                    {   Condition.DepthOfCondition.pov,new int[2]{2,0}},
                    { Condition.DepthOfCondition.sred,new int[2]{2,0}},
                    {  Condition.DepthOfCondition.glub,new int[2]{2,0}},
                    { Condition.DepthOfCondition.giper,new int[2]{2,0}},
                  },

                  new Dictionary<Condition.DepthOfCondition, string>() { 
                  { Condition.DepthOfCondition.pov, "в пределах эмали, зондирование слабоболезненно по поверхности дефекта. " }, 
                  { Condition.DepthOfCondition.sred, "в пределах плащевого дентина. Зондирование болезненно по эмалево-дентинному соединению. " }, 
                  { Condition.DepthOfCondition.glub, "в пределах околопульпарного дентина. Полость зуба не вскрыта. Зондирование болезненно по всему дну полости. " }, 
                  { Condition.DepthOfCondition.giper, "в пределах околопульпарного дентина, сообщается с полостью зуба в одной точке. Полость зуба  вскрыта в одной точке - пульпа жизнеспособна, незначительно кровоточит - кровоточивость купировалась самостоятельно. Зондирование болезненно в точке сообщения. " } 
                  },

                  "клиновидная полость",
                   new Dictionary<Condition.DepthOfCondition, string>() { 
                  { Condition.DepthOfCondition.pov, "в пределах эмали, " },
                  { Condition.DepthOfCondition.sred, "в пределах плащевого дентина, " },
                  { Condition.DepthOfCondition.glub, "в пределах околопульпарного дентина, не сообщается с полостью зуба, " }, 
                  { Condition.DepthOfCondition.giper, "в пределах околопульпарного дентина, близко располагается с полостью зуба, " } },

                  "полость правильной формы ",
                  2, 4,

                  Color.Aqua,

                  "клиновидная полость_клиновидные полости|сообщается_сообщаются|дефекта_дефектов",

                   new Dictionary<Condition.DepthOfCondition, List<Affiction>>() {

                   {Condition.DepthOfCondition.pov,new  List<Affiction> (){new Affiction("eod",6),new Affiction("termotest",1)} },
                      {Condition.DepthOfCondition.sred,new  List<Affiction> (){new Affiction("eod",8),new Affiction("termotest",1)} },
                      {Condition.DepthOfCondition.glub,new  List<Affiction> (){new Affiction("eod",12),new Affiction("termotest",1)}  },
                      {Condition.DepthOfCondition.giper,new  List<Affiction> (){new Affiction("eod",15),new Affiction("termotest",2),new Affiction("polost",1)}  }
                   }
                  ));

              condiList.Add(new Condition("Несостоятельный контакт",
                  new List<Face.faceSide>() { Face.faceSide.distal, Face.faceSide.medial },
                  new Condition.DepthOfCondition[] { Condition.DepthOfCondition.none },
                  new Dictionary<Condition.DepthOfCondition, string>(),
                 "несостоятельный контакт",
                  3, 3,
                  Color.Black,
                  "несостоятельный контакт_несостоятельные контакты",
                    new Dictionary<Condition.DepthOfCondition, List<Affiction>>()
                    {{Condition.DepthOfCondition.none, new  List<Affiction>(){}}
                    }
                  ));

              return condiList;
          }

          #endregion 

          #region TextManipulations
          public static string MultiplyText(string Text, string TextMultiplicator)
          {
              string[] changerTextBlocks;
              if (TextMultiplicator != "")
              {
                 
                      List<string> finParts = new List<string>();
                      string[] parts = TextMultiplicator.Split('|');
                      foreach (string part in parts)
                      {
                          string[] splited = part.Split('_');
                          if (splited.Length == 2)

                              finParts.AddRange(splited);
                      }
                      changerTextBlocks = finParts.ToArray();

                  
              }
              else return Text;


              string multiText = "";
              string currentText = Text;

              int currentPosition = 0;
              int currentLenght = 0;
              for (int i = 0; i < changerTextBlocks.Length; i += 2)
              {
                  currentLenght = currentText.Substring(currentPosition).IndexOf(changerTextBlocks[i]) + changerTextBlocks[i].Length;
                  if ((currentPosition + currentLenght) <= currentText.Length)
                      multiText += currentText.Substring(currentPosition, currentLenght).Replace(changerTextBlocks[i], changerTextBlocks[i + 1]);

                  currentPosition = currentPosition + currentLenght;
              }
              if(currentPosition<currentText.Length)
              {
                  multiText += currentText.Substring(currentPosition);
               }
              return multiText;
            

          }

          #endregion
          #region ListsManipulation
          public static List<Materials> CopyMainMaterialList()
        {
            List<Materials> copyedMatList = new List<Materials>();
            foreach (Materials mainMat in mainMatList)
            {
                copyedMatList.Add(new Materials(mainMat));
            }
            return copyedMatList;
        }
public static List<Materials> CopyMaterialList(List<Materials> matListToCopy)
        {
            List<Materials> copyedMatList = new List<Materials>();
            foreach (Materials mainMat in matListToCopy)
            {
                copyedMatList.Add(new Materials(mainMat));
            }
            return copyedMatList;
        }

public static void SaveDefaultMaterialList(List<Materials> matListToSave)
        {
            mainMatList = CopyMaterialList(matListToSave);
            WriteToBinaryFile<List<Materials>>(path2matDefault, mainMaterialList, false);
        }

        public static void SaveCurrentMaterialList(List<Materials> matListToSave)
        {
            mainMatList = CopyMaterialList(matListToSave);
            WriteToBinaryFile<List<Materials>>(path2matCurrent, mainMaterialList, false);
        }

        static void SaveAnesteticList()
        {
            WriteToBinaryFile<List<Anesthetics>>(path2anest, anesteticsList, false);
             WriteToBinaryFile<List<Anesthetics>>(path2appl, applicationList, false);
            
        }
         public static void CancelChangesMaterialList()
         {
             mainMatList = ReadFromBinaryFile<List<Materials>>(path2matCurrent);
         }
         public static void ResetAnestList()
        {

            anesteticsList = CreateDefaultAnesteticsList();

        }
       public static void ResetApplAnestList()
        {
            applicationList = CreateDefaultApplicateAnestList();
        }
        public static void ResetMaterialList()
        {
            try
            {
                mainMatList = ReadFromBinaryFile<List<Materials>>(path2matDefault);
            }
            catch
            {
                try
                {
                    mainMatList = ReadFromBinaryFile<List<Materials>>(path2matAdminDefault);
                }
                catch
                {
                     CreateDefaultMaterialList();
                    WriteToBinaryFile<List<Materials>>(path2matDefault, mainMaterialList, false);
                    

                    WriteToBinaryFile<List<Materials>>(path2matAdminDefault, mainMaterialList, false);
                    System.IO.File.SetAttributes(path2matAdminDefault, System.IO.FileAttributes.Hidden);
                    System.IO.File.SetAttributes(path2matAdminDefault, System.IO.FileAttributes.ReadOnly);

                }
            }
            
        }

        public static bool AddMaterial(Materials newMat)
        {
            foreach (Materials oldMat in mainMatList)
            {
                if (oldMat.Name == newMat.Name)
                    return false;
            }
            mainMatList.Add(newMat);
           
            return true;

        }

        public static bool RemoveMaterial(Materials mat, bool changeWithNew)
        {
            foreach (Materials oldMat in mainMatList)
            {
                if (oldMat.Name == mat.Name)
                {
                    mainMatList.Remove(oldMat);
                    if (changeWithNew) mainMatList.Add(mat);
                    
                    return true;
                }
            }                     
            return false;

        }
        public static void SaveCurrentChanges()
        {
            SaveCurrentMaterialList(mainMatList);
        }

          #endregion

       #region BinaryWriter and Dictionary methods

       static void Write(Dictionary<string, string> dictionary, string file)
        {
            using (FileStream fs = File.OpenWrite(file))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                // Put count.
                writer.Write(dictionary.Count);
                // Write pairs.
                foreach (var pair in dictionary)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);
                }
            }
        }

        static Dictionary<string, string> Read(string file)
        {
            var result = new Dictionary<string, string>();
            using (FileStream fs = File.OpenRead(file))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                // Get count.
                int count = reader.ReadInt32();
                // Read in all pairs.
                for (int i = 0; i < count; i++)
                {
                    string key = reader.ReadString();
                    string value = reader.ReadString();
                    result[key] = value;
                }
            }
            return result;
        }

        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public static void SaveDictionary()
        {
            using (StreamWriter sw = new StreamWriter("dataBlocks.txt"))
            {
                foreach (KeyValuePair<string, string> entry in blocksDictionary)
                    sw.WriteLine(entry.Key + "=" + entry.Value);
            }
        }

        public static string Get(string key)//метод Get - берет из массива значение по ключу
        {
            if (blocksDictionary.ContainsKey(key))//проверка есть ли такой ключ в словаре
            {
                string value = "";//само значение которое возвращается
                if (blocksDictionary.TryGetValue(key, out value))//попытка взять значение
                    return value;//в случае успеха - возвращаем значение
                else return "ОШИБКА - ПУСТОЙ БЛОК";//в случае если взять значение не получается возвращаем ошибку

            }
            else return "ОШИБКА - МАШАЛА НЕВЕРНЫЙ КЛЮЧ!";//если ключ неверный и не совпадает ни с одним ключом словаря

        }
        public static bool Put(string key, string value)//метод Put -кладет значение в словарь
        {
            if (value != null)//если значение не нулевое - тогда пытаемся его ввести
            {
                if (blocksDictionary.ContainsKey(key))//если ключ верный
                {

                    blocksDictionary[key] = value;//вводим значение в словарь по ключу
                    return true;//возращаем истину - ввести значение получилось
                }
                else return false;//иначе ложь - неверный ключ
            }
            else return false;//или ложь - значение нулевое
        }

        public static string GetBlock(string Key)
        {
            string value = "";
            try
            {
                value = blocksDictionary[Key];
            }

            catch
            {
                value = "ERROR";
            }

            return value;

        }
       #endregion

    }


    

}
