# UnityQuizGame
Test your knowledge with the quiz.
Small game in Unity (editor ver 2022.3.4f1).

Scripts>

public class QuestionData
	Used for serialization data from json format to an object of this class.

public class QuestionMeneger : MonoBehaviour
	Manage one current question.
	Put data into UI and check answer result.

public interface TestLoader 
	Interface for load data of test questions.

public class TestFromFileLoader : MonoBehaviour, TestLoader
	Load json string from file.

public class TestParserJson
	Parse json string to List<QuestionData>.

public class TestManager : MonoBehaviour
	Manage Test.
	Initiate loading question data.
	Allow to get data of the next question.

Images generated in Bing.
Font are free for commertial use. https://1001fonts.com/