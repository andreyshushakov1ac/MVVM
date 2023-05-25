using Lab6.Model;
using System;
using System.ComponentModel;
using System.Windows;


namespace Lab6.ViewModels
{
    class MyViewModel : INotifyPropertyChanged
    {
        private int result;    //Результат возведения в степень
        
        //введённое число
        private String _num;
        public String num
        {
            get
            {
                return _num;//Convert.ToInt32(num);
            }
            set
            {
                _num = value;
                RaisePropertyChanged("num");
            }
        }

        //Вывод результата возведения в степень
        public int Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
                RaisePropertyChanged("Result");
            }
        }

        //перевод строки в целочисл. тип
        public int NUM
        { 
            get {
                
                return Convert.ToInt32(num);//Convert.ToInt32(num);
                }
            set
            {
                RaisePropertyChanged("NUM");
            }
        }

        private RelayCommand clickCommand;
        public RelayCommand ClickCommand
        {
            get
            {
                return clickCommand ??
                  (clickCommand = new RelayCommand(obj =>
                  {  //при нажатии на кнопку производится расчет результата возведения в степень
                      Numbers numbers = new Numbers();  //создадим объект класса модели
                     if (IsChecked == true && IsChecked1 == false)
                        Result = numbers.kvadrat(NUM);  //если выбрали квадрат
                     else if (IsChecked1 == true && IsChecked == false)
                          Result = numbers.kub(NUM); //если выбрали куб
                      else if (IsChecked1 == true && IsChecked == true)
                      {
                          Result = numbers.kub(numbers.kvadrat(NUM)); //если выбрали оба чекбокса
                      }
                  }));
            }
        }

        //Проверка чекбокса1
        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; RaisePropertyChanged("ch");
                //MessageBox.Show($"checkbox kv is checked: {_IsChecked}");
            }
        }
        //Проверка чекбокса2
        private bool _IsChecked1;
        public bool IsChecked1
        {
            get { return _IsChecked1; }
            set { _IsChecked1 = value; RaisePropertyChanged("ch"); }
        }

        //Сбросить
        private RelayCommand resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                return resetCommand ??
                  (resetCommand = new RelayCommand(obj =>
                  {
                      Result = 0; //обнуление результата
                      num = ""; NUM = 0;
                      IsChecked1 = false; _IsChecked1 = false;
                      IsChecked = false; _IsChecked = false;
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
        public MyViewModel() //пустой конструктор
        {
        }
    }
}
