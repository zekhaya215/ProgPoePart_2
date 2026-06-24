Cybersecurity Awareness Chatbot – Part 3

 Project Overview

The Cybersecurity Awareness Chatbot is a WPF desktop application developed in C#. It is designed to educate users about cybersecurity threats through an interactive chat system. The chatbot uses modular programming principles where each class has a specific responsibility, ensuring clean architecture, maintainability, and scalability.

Part 3 extends the chatbot by introducing Natural Language Processing (NLP), task management, activity logging, a cybersecurity quiz system, user memory, and JSON data persistence.

 Project Structure and Class Explanations
Models
 UserMemory.cs

This class stores user-related information during conversations.

Responsibilities:

* Stores UserName
* Stores FavouriteTopic
* Enables memory-based personalization
* Allows the chatbot to remember user preferences

 CyberTask.cs

This model represents a cybersecurity-related task.

Responsibilities:

* Stores task ID
* Stores task title
* Stores task description
* Stores reminder information
* Stores completion status
* Stores creation date

 QuizQuestion.cs

This class represents a cybersecurity quiz question.

Responsibilities:

* Stores question text
* Stores answer options
* Stores correct answer
* Stores explanation
* Supports quiz functionality

Services

 KeywordHandler.cs

Responsible for identifying cybersecurity-related keywords from user input.

Recognized Topics:

* Passwords
* Phishing
* Scams
* Privacy
* Malware
* Hacking
* Viruses
* Two-Factor Authentication (2FA)

Responsibilities:

* Detects cybersecurity keywords
* Classifies user queries
* Supports chatbot topic recognition

 ResponseManager.cs

Manages chatbot responses and cybersecurity knowledge.

Responsibilities:

* Stores cybersecurity responses in dictionaries
* Provides random responses
* Provides detailed follow-up information
* Supports "Tell Me More" functionality
* Generates dynamic chatbot replies

Topics Included:

* Password Security
* Phishing
* Scams
* Privacy
* Malware
* Hacking
* Viruses
* Two-Factor Authentication (2FA)

 SentimentAnalyzer.cs

Detects emotional tone within user messages.

Supported Sentiments:

* Worried
* Scared
* Afraid
* Frustrated
* Angry
* Upset
* Curious
* Interested
* Confused
* Happy
* Excited

Responsibilities:

* Detects user emotions
* Provides supportive responses
* Improves user engagement

 VoiceManager.cs

Handles audio playback functionality.

Responsibilities:

* Loads welcome audio
* Plays WAV sound files
* Enhances user experience

Technologies:

* System.Media.SoundPlayer

 DelegateHandler.cs

Demonstrates the use of delegates in C#.

Responsibilities:

* Defines BotResponseDelegate
* Executes methods dynamically
* Demonstrates event-driven programming

 NLPIntentManager.cs

Provides Natural Language Processing (NLP) capabilities.

Recognizes:

* Task requests
* Reminder requests
* Quiz requests
* Activity log requests

Examples:

* "Add task update antivirus"
* "Remind me to change my password"
* "Start quiz"
* "Show activity log"

Responsibilities:

* Detects user intent
* Routes requests to appropriate services
* Improves chatbot intelligence

 ActivityLogger.cs

Tracks user actions throughout the application.

Responsibilities:

* Records chatbot interactions
* Records task actions
* Records quiz activity
* Maintains activity history

Functions:

* Log()
* GetRecentLog()
* GetFullLog()
* GetCount()
 TaskManager.cs

Manages cybersecurity tasks.

Responsibilities:

* Create tasks
* Retrieve tasks
* Mark tasks as complete
* Delete tasks
* Log task actions

 TaskStorageHelper.cs

Handles task persistence using JSON files.

Responsibilities:

* Save tasks to tasks.json
* Load tasks from tasks.json
* Update tasks
* Delete tasks
* Maintain task history between sessions

Technologies:

* Newtonsoft.Json
* File I/O Operations

 QuizManager.cs

Manages the cybersecurity quiz system.

Responsibilities:

* Loads quiz questions
* Tracks scores
* Validates answers
* Provides feedback
* Displays final results

Features:

* Multiple-choice questions
* True/False questions
* Explanations for answers
* Final performance evaluation

 Main Application

 MainWindow.xaml

Provides the graphical user interface.

Features:

* Chatbot tab
* Task Assistant tab
* Quiz tab
* Activity Log tab
* Image display
* User input controls
* Send, Clear, and Exit buttons

 MainWindow.xaml.cs

Acts as the controller of the application.

Responsibilities:

* Handles chatbot conversation flow
* Processes user input
* Integrates all services
* Manages memory
* Controls task management
* Controls quiz functionality
* Controls activity logging
* Handles NLP processing
* Updates the graphical interface



 Part 3 Features Implemented

 User Memory

The chatbot remembers:

* User name
* Favourite cybersecurity topic

Example:

User: My name is Zekhaya

Chatbot: Nice to meet you, Zekhaya!

Natural Language Processing (NLP)

The chatbot understands user intent.

Examples:

* Add task Enable 2FA
* Remind me to update antivirus
* Start quiz
* Show activity log

 Task Assistant

Users can:

* Add tasks
* Complete tasks
* Delete tasks
* Store reminders

All tasks are saved using JSON persistence.

 Cybersecurity Quiz

Includes:

* Multiple-choice questions
* True/False questions
* Instant feedback
* Score tracking
* Final performance message

 Activity Logging

Records:

* User actions
* Task actions
* Quiz activities
* Chatbot interactions

JSON Persistence

Tasks are stored permanently in:

tasks.json

This ensures data remains available after restarting the application.

 How the System Works

1. User enters a message.
2. MainWindow processes the message.
3. NLPIntentManager checks for intent.
4. KeywordHandler identifies cybersecurity topics.
5. SentimentAnalyzer checks emotional tone.
6. ResponseManager generates a response.
7. ActivityLogger records the action.
8. VoiceManager plays audio feedback.
9. Chat updates on screen.


 Technologies Used

* C#
* WPF (.NET)
* XAML
* Object-Oriented Programming (OOP)
* Delegates
* Dictionaries
* Lists
* JSON Serialization
* Newtonsoft.Json
* File I/O
* System.Media.SoundPlayer



 Summary

The Cybersecurity Awareness Chatbot Part 3 demonstrates advanced C# and WPF development concepts including Natural Language Processing, user memory, task management, activity logging, quiz systems, JSON persistence, sentiment analysis, delegates, and modular software architecture.

The project provides an interactive educational platform that helps users learn cybersecurity concepts while showcasing object-oriented programming principles, clean code practices, and modern desktop application development techniques.

