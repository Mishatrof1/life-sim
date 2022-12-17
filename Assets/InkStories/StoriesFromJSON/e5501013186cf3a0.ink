VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0

My wife wants to go out to dinner but I wanted to watch a hockey game.
What do I do?
* [Go out to dinner and record the game to watch later]
    -> res1
* [Tell her I want to stay home and watch the game and order food to be delivered]
    -> res2
* [Make dinner for the two of you and watch the game during dinner]
    -> res3
* [Go out to dinner early so that I can come back and see the end of the game]
    -> res4

=== res1 === 
The dinner is expensive but my wife and I have a great time, however, someone at the restaurant ruins the game for me and I end up getting in a fight.
~TextForLog = "Well, the night went well with my wife and I was looking forward to watching the game at home until someone ruined it and I got carried away and got into a fight. That was kind of dumb of me."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-100%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My wife gets annoyed with me but I get to watch the entire game. Also, I saved money on cheap delivery.
~TextForLog = "I definitely saved money by ordering cheap delivery and I had a great time watching the game... but I realized by the end of the game how agitated my wife was. Whoops!"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
My wife loves the idea and enjoys watching the game with me. However, I burn myself badly when cooking dinner.
~TextForLog = "My wife actually loved the idea of eating together and watching the game since I put in the effort to make us dinner. Dinner was delicious, but I burned myself really badly on the stove!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
My wife is happy with me and we have a great time. The dinner is expensive but I get back in time to see the end of the game.
~TextForLog = "All in all, I’m glad I made this decision. The game only got interesting at the end anyway and I saw the whole last bit, plus my wife and I had a great night."
~Character0WealthCh = "%-50%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
