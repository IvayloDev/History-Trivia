using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.IO;



	public struct Question {
		public string questionText;
		public string answerA;
		public string answerB;
		public string answerC;
		public string answerD;
		public int correctAnswerID;
	}
	
	[XmlRoot("QuestionsRoot")]
	public class QuestionData {
	[XmlArray("Questions")]
	[XmlArrayItem("Question")]




	public  List<Question> questions = new List<Question>();
	
	public static QuestionData LoadFromText(string text) {


		try {
	
			XmlSerializer serializer = new XmlSerializer(typeof(QuestionData));            
			return serializer.Deserialize(new StringReader(text)) as QuestionData;
		} catch (Exception e) {
			UnityEngine.Debug.LogError("Exception loading question data: " + e);
			return null;
		}
	}
}
