VAR StoryTittle = ""
VAR StoryQuestion = "The real problem is that my grandmother died several months ago. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 6
VAR Character0MaxAgeSc = 18

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0
VAR Character0WealthCh = 0

I'm in my bed about to go to sleep when my grandmother comes in my room muttering in a confusing manner.
The real problem is that my grandmother died several months ago. What should I do?
* [Go up to her and hug her]
    -> res1
* [Ask her what she wants]
    -> res2
* [Hide under my blankets, ignore her, it's a dream.]
    -> res3

=== res1 === 
She screams and shoves me and I crash into my dresser and hurt myself
~TextForLog = "Somehow no one else hears the scream besides me, even though it was loud. Meanwhile, I am in pain, bruises on my back, cuts on my arms. And my grandmother vanished. Now, I can't fall asleep."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
She looks directly at me, tells me to look in her old sewing kit and vanishes.
~TextForLog = "We got her sewing kit after she died and it was stored out in the garage. I immediately go to the garage and find it buried in a box. I open it up and there's $400 in there! It must have been money she was saving for something. I guess... to give to me? My family was getting ready to throw that kit out. I now have a whole new understanding of the world."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0WealthCh = "%400%"
* [Ok]
-> END

=== res3 === 
I hide under the blankets until this dream ends. Eventually she vanishes and now there is $10 on my nightstand.
~TextForLog = "OK, I thought that was a dream at first... but then $10 inexplicably shows up on my nightstand after my grandma vanishes. That couldn't have been a dream. There's no other reason that money could've showed up there. I do remember back when my grandma was alive she said she had money saved for me... is she trying to give me money?"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%10%"
* [Ok]
-> END
