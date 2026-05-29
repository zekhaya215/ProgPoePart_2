Cybersecurity Awareness Chatbot

The Cybersecurity Awareness Chatbot is a WPF desktop application developed in C#.
It is designed to educate users about cybersecurity threats through an interactive chat system. 
The chatbot uses modular programming, where each class has a specific responsibility to ensure clean architecture and maintainability.


Project Structure and Class Explanations

 Models

 UserMemory.cs
This class is responsible for storing user-related information during the conversation.
It holds data such as the user's name and favourite cybersecurity topic. 
This allows the chatbot to remember users and personalize responses.

- Stores `UserName`
- Stores `FavouriteTopic`
- Enables simple memory-based personalization


 Services

KeywordHandler.cs
This class is responsible for detecting cybersecurity-related keywords in user input.
It converts the user message to lowercase and checks for important terms such as password, phishing, scam, privacy, malware, hacking, and virus.

- Identifies main topic from user input
- Returns a keyword string used for response generation
- Acts as the classification system of the chatbot



ResponseManager.cs
This class manages all chatbot responses. It stores a dictionary of cybersecurity topics and multiple responses for each topic. 
It randomly selects a response to make conversations more dynamic.

- Stores predefined responses in a Dictionary
- Provides `GetRandomResponse()` for topic replies
- Provides `GetMoreInfo()` for extended explanations
- Ensures varied and natural chatbot replies



 SentimentAnalyzer.cs
This class analyses the emotional tone of the user's message. It detects emotions such as worried, angry, confused, curious, and happy. Based on the detected sentiment, it returns supportive or encouraging responses.

- Detects user emotions from text
- Provides emotional support responses
- Improves user interaction experience



 VoiceManager.cs
This class handles audio playback for the chatbot. It plays a WAV file (welcome message) using the SoundPlayer class.

- Loads audio file from `Audio/welcome.wav`
- Plays welcome sound on startup or response
- Enhances user experience with sound feedback

 DelegateHandler.cs
This class demonstrates the use of delegates in C#. It allows methods to be passed and executed dynamically, improving flexibility and modular design.

- Defines `BotResponseDelegate`
- Executes assigned response methods dynamically
- Demonstrates event-driven programming concept

 Main Application

 MainWindow.xaml & MainWindow.xaml.cs
This is the core of the application where the user interface and chatbot logic are combined.

 MainWindow.xaml (UI)
- Chat display area
- User input textbox
- Send, Clear, and Exit buttons
- Image display for visual design

MainWindow.xaml.cs (Logic)
- Controls chatbot flow and interaction
- Connects all services together
- Handles user input and bot responses
- Manages:
  - Keyword detection
  - Sentiment analysis
  - Memory system
  - Voice playback
  - Conversation flow

 How the System Works

1. User types a message
2. MainWindow processes input
3. KeywordHandler detects topic
4. ResponseManager generates response
5. SentimentAnalyzer checks emotion
6. VoiceManager plays audio
7. Chat updates on screen

 Technologies Used

- C# (.NET WPF)
- XAML UI Design
- Object-Oriented Programming (OOP)
- Delegates
- Dictionary and List Collections
- System.Media (Audio Playback)

 

 Summary

This project demonstrates modular software design, chatbot development, user interaction handling, sentiment analysis, and multimedia integration using C# and WPF.
Each class is designed with a single responsibility to ensure clean, maintainable, and scalable code.
