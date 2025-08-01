using System;
using System.Collections.Generic;

// Comment class
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video class
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // Create videos
        var video1 = new Video("How to Cook Rice", "Chef Anna", 300);
        video1.AddComment(new Comment("John", "Great recipe!"));
        video1.AddComment(new Comment("Mary", "Tried it and loved it."));
        video1.AddComment(new Comment("Alex", "Can you do pasta next?"));

        var video2 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        video2.AddComment(new Comment("Sam", "Very helpful, thanks!"));
        video2.AddComment(new Comment("Linda", "I learned a lot."));
        video2.AddComment(new Comment("Tom", "Please make more tutorials."));

        var video3 = new Video("Travel Vlog: Paris", "Wanderlust", 450);
        video3.AddComment(new Comment("Emma", "Paris looks amazing!"));
        video3.AddComment(new Comment("Lucas", "Adding this to my bucket list."));
        video3.AddComment(new Comment("Sophia", "Great video!"));

        var video4 = new Video("Unboxing New Phone", "TechGuy", 350);
        video4.AddComment(new Comment("Mike", "Nice phone!"));
        video4.AddComment(new Comment("Sara", "Is it worth the price?"));
        video4.AddComment(new Comment("Nina", "Thanks for the review."));

        // Add videos to a list
        var videos = new List<Video> { video1, video2, video3, video4 };

        // Display info for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}