using System;

namespace Kodjo
{
	public class TextStorageRus : TextStorage
	{
		public override string Language{ get{ return Languages.RUSSIAN; } }
		
		
		public TextStorageRus() : base(){}
		
		
		public override string getMessage( string _type ){
			string message = "";
			switch( _type ){
				case Texts.GREETING:
					message = "Guten tag и добро пожаловать в Kodjo 1.01!";
					break;
				case Texts.GUIDE:
					message = 
						"Чтобы начать новую игру, введите \"" + Commands.NEW_GAME + 
						"\" (без кавычек). Для получения списка доступных команд " +
						"введите \"" + Commands.LIST + "\".";
					break;
				case Texts.UNKNOWN_COMMAND:
					message = 
						"Неизвестная команда. Для получения списка доступных команд " +
						"введите \"" + Commands.LIST + "\".";
					break;
				case Texts.NEW_GAME:
					message = "Начата новая игра. GLHF!";
					break;
				case Texts.HELP:
					message = 
						"Задача - очистить поле, открывая попарно одинаковые элементы. " + 
						"Чтобы открыть пару элементов, введите их ID через пробел.";
					break;
				case Texts.MOVE:
					message = "Введите следующий ход.";
					break;
				case Texts.GUESS_CORRECT:
					message = "Элементы совпали, отлично!";
					break;
				case Texts.GUESS_INCORRECT:
					message = "Элементы не совпали.";
					break;
				case Texts.MOVE_INCORRECT:
					message = 
						"Некорректный ход. Введите два ID элементов, " + 
						"оставшихся на поле, через пробел.";
					break;
				case Texts.LOSE:
					message = 
						"Увы, вы проиграли. Не расстраивайтесь! " +
						"Начните новую игру или займитесь чем-то другим.";
					break;
				case Texts.WIN:
					message = "Ура, победа! Если хотите, начните новую игру.";
					break;
				case Texts.LIST:
					message = "Список команд:";
					break;
				case Texts.LIST_PS:
					message = "Любая иная команда будет считаться ходом в игре.";
					break;
				case Texts.LANGUAGE_ALREADY_SET:
					message = "Уже установлен русский язык.";
					break;
				case Texts.LANGUAGE_SET:
					message = "Установлен русский язык.";
					break;
				case Texts.FAREWELL:
					message = "До встречи!";
					break;
			}
			
			return message;
		}
		
		public override string getCommandDescription( string _command ){
			string description = "";
			switch( _command ){
				case Commands.NEW_GAME:
					description = 
						"Начать новую игру. Вы можете установить размер поля, " + 
						"указав его через пробел, например, \"" + Commands.NEW_GAME + 
						" 6\" (без кавычек). Имейте в виду, что в данной версии игры " +
						"поле квадратное и при вводе нечетного числа в качестве размера " + 
						"оно будет увеличено на 1.";
					break;
				case Commands.HELP:
					description = "Вывод справки по игре.";
					break;
				case Commands.LIST:
					description = "Допустимые команды и их пояснения.";
					break;
				case Commands.LANGUAGE:
					description = 
						"Установить язык текста в игре. Можно ввести как полное " + 
						"название, так и сокращение. Возможные языки: ";
					break;
				case Commands.EXIT:
					description = "Выход из игры.";
					break;
			}
			
			return description;
		}
	}
}
