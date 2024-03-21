using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace RCLibrary
{
    //ToDo #2.1 Абстрактный класс для пользователей системы. +
    public abstract class User : IFile
    {
        private string email = string.Empty;
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string middleName = "-";
        private string phoneNumber = string.Empty;
        private string password = string.Empty;

        private static Regex FormatEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        [DisplayName("Электронная почта")]
        public string? Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Предупреждение: Электронная почта не должна быть пустой!");
                if (!FormatEmail.IsMatch(value))
                    throw new ArgumentException("Предупреждение: В электронной почте должен быть символ \"@\" и \".\". (Например: \"user@gmail.com\")");
                email = value.ToLower();
            }
        }

        [DisplayName("Фамилия")]
        public string? LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Предупреждение: Фамилия не должна быть пустой");
                if (value.Any(char.IsDigit))
                    throw new ArgumentException("Предупреждение: Фамилиия должна состоять только из букв");
                lastName = value;
            }
        }

        [DisplayName("Имя")]
        public string? FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Предупреждение: Имя не должно быть пустым");
                if (value.Any(char.IsDigit))
                    throw new ArgumentException("Предупреждение: Имя должно состоять только из букв");
                firstName = value;
            }
        }

        [DisplayName("Отчество")]
        public string? MiddleName
        {
            get => middleName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    middleName = "-";
                else if (value.Any(char.IsDigit))
                    throw new ArgumentException("Предупреждение: Отчество должно состоять только из букв");
                else
                    middleName = value;
            }
        }

        [DisplayName("Номер телефона")]
        public string? PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 10)
                    throw new ArgumentException("Предупреждение: Номер телефона не должен быть пустым");

                long.Parse(value); // Пытаемся преобразовать строку в число
                phoneNumber = value;
            }
        }

        [DisplayName("Пароль")]
        public string? Password
        {
            get => password;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length >= 8)
                    password = value;
                else
                    throw new ArgumentException("Предупреждение: Пароль должен быть не пустым и иметь хотя бы 8 символов");
            }
        }

        [DisplayName("Роль")]
        public string? TypeClass { get; set; }

        public abstract bool Serialize();
        public abstract bool Deserialize();

        public override string ToString()
        {
            return $"{lastName} {FirstLetter(firstName)}.{FirstLetter(middleName)}";
        }

        private string FirstLetter(string? s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s[0].ToString().ToUpper();
        }
    }
}
