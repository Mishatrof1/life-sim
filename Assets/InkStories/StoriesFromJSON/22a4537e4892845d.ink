VAR StoryTittle = ""
VAR StoryQuestion = "What replacement should I get?"
VAR StoryCategory = "Gold"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 18
VAR Character0MaxAgeSc = 65

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0
VAR Character0WealthCh = 0

I'm at the store and they're out of my creamer that I use for coffee.
What replacement should I get?
* [The brand name option.]
    -> res1
* [An expensive non-dairy creamer]
    -> res2

=== res1 === 
I take this home and use it and it's curdled and I get really sick.
~TextForLog = "The brand name option was really cheap so I thought it might be a good choice but it turned out to be a horrible choice! This is what I get for settling for a brand name and going for something cheap! Never again! Saving money was not worth throwing up for two days!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-2%"
* [Ok]
-> END

=== res2 === 
This creamer is expensive and it is made from oats, but it's delicious and healthy!
~TextForLog = "This creamer was 4 times as expensive as the other choice but I really love it. And it's really healthy too, I actually feel good after having it. Now I can have coffee for every meal!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-8%"
* [Ok]
-> END
