VAR StoryTittle = ""
VAR StoryQuestion = "When I wake up the channel has been changed to the History channel. What do I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 12
VAR Character0MaxAgeSc = 50

VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0

I'm home alone and watching TV and I fall asleep.
When I wake up the channel has been changed to the History channel. What do I do?
* [Change the channel back to my channel.]
    -> res1
* [Turn the TV off.]
    -> res2
* [Just go back to sleep.]
    -> res3

=== res1 === 
I change the channel back, and then it changes back to the History channel again. And I get the feeling I am not alone.
~TextForLog = "After the channel changes back on its own, I notice I can feel someone or something sitting beside me on the couch. Though I look and no one is there. I don't change the channel, I leave it. I watch an entire program on the History channel and then once it's done the TV turns off. And then I cannot sleep at all that night and am so sleep deprived the next day."
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I turn the TV off and it immediately EXPLODES!
~TextForLog = "Okay, I am fairly certain I was not alone. There was some supernatural or paranormal stuff happening. For the channel to be changing and then for the TV to explode because I turned it off... someone or something was there and didn't like what I was doing. That was a horrible feeling. Not to mention, I have to buy a new TV now!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-300%"
* [Ok]
-> END

=== res3 === 
I go back to sleep on the couch but I wake up hours later and all the windows have been opened and I get sick.
~TextForLog = "This was the weirdest experience. I thought maybe the TV channels changing was in my head but then after I went to sleep and all the windows were opened... and I know I had closed them before... that really makes me wonder. Maybe I wasn't truly alone that night. But right now I am so sick I just need to focus on getting better."
~Character0HealthCh = "%ValueRef:0:-%"
* [Ok]
-> END
