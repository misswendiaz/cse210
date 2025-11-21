using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Console.WriteLine();

        Console.WriteLine("=================================================================================================");

        // First Video
        Video video1 = new Video("O Holy Night (SATB) - Jay Rouse", "The Lorenz Corporation", 373);
        // https://www.youtube.com/watch?v=_hdDnw1YLnk&list=RD_hdDnw1YLnk&start_radio=1

        video1.AddComment(new Comment("JerryLedesma1", "This is my favorite Christmas carol. Ever. This is arrangement is the BEST arrangement BY FAR. I've tried listening to others and they just DON'T come anywhere near this. I LOVE THIS SO MUCH!!!"));

        video1.AddComment(new Comment("izzyb5644", "So excited to perform this next week!!"));

        video1.AddComment(new Comment("temitopefaleti7053", "Jay Rouse is awesome and this is my mum's favourite carol. Keep up the great work Lorenz and friends because these uploads are needed more than ever before on these unprecedented times #keepsafeeveryone# 😃"));

        video1.AddComment(new Comment("newgate1649", "I love this arrangement. This is awesome."));

        video1.AddComment(new Comment("VictorPerscodvnp", "A beautiful arrangement Jay!"));

        video1.AddComment(new Comment("MarcusB-qr1hk", "This is amazing!"));

        video1.AddComment(new Comment("renanvalcacio1941", "This is Wonderful"));

        video1.AddComment(new Comment("odilondasilvarocha", "ouvindo novamente...ele alterou os tempos, tornando mais lento...existem muitos arranjos deste belíssimo hino, e há melhores do que isto.   não tira o mérito de Jay Rouse em outros arranjos, e nas cantatas que já fez."));

        // Second Video
        Video video2 = new Video("O Holy Night | BYU Noteworthy", "BYU Noteworthy", 249);
        // https://www.youtube.com/watch?v=HdTbfmJe1O8

        video2.AddComment(new Comment("zinawood4055", "The interactive with the nativity makes me feel and realize myself worshipping Christ's birth today instead of observing an event in the past! thankZ"));

        video2.AddComment(new Comment("briananderson8428", "I'm an agnostic, and I still completely resonate with these beautiful singers and this joyful musical feat!"));

        video2.AddComment(new Comment("DreamyVibezMusic", "This sound is so wonderful. The person who is reading this comment, I wish you great success, health, love and happiness!"));

        video2.AddComment(new Comment("hersheyskwertz9315", "Hung up on this song for the last couple days. Praise Jesus for those beautiful voices and even more so for our salvation. Amen!"));

        video2.AddComment(new Comment("canden-t7w", "✝O Holy Night is such a good and beautiful song !. The Biblical Jesus Christ is real love, hope, goodness, truth, wisdom, real and the universal king !!."));

        video2.AddComment(new Comment("Sapphireprincess8", "THE SLAVE IS OUR BROTHER , THE HOMELESS , THE OPRESSED . THE HURTING ."));

        video2.AddComment(new Comment("ac-kj9lb", "This is just what Jesus Christ expects of us when we sing about Him.  So clean and clear are the angelic voices of these  individual singers who together forms an angelic choir. An exceptional par excellence performance that not only engages you but also evokes your spiritual senses to feel the presence and supernatural power of God. The Best from the Noteworthy choir of BYU."));

        video2.AddComment(new Comment("colinbateman8233", "I’m 63 years old and I truly appreciate the songs I grew up with for me it makes the season thank you for sharing Body and peace of Christ be with you."));

        video2.AddComment(new Comment("bigunone", "Anyone else old enough to remember the Mormon Tabernacle Choir Christmas special was played on TV? Thank you lovely ladies!"));

        video2.AddComment(new Comment("AW-xc8dm", "So beautiful when they're not shouting."));

        video2.AddComment(new Comment("michelleshaw1211", "Thank you BYU.  Great Family memories for me.  I am alone now and blind so this is precious to me.  I was chosen to perform this as a solo at 7 yrs. old.  I have no doubt it could even come close to anybody's version.  I really can't remember.  Our Family acted out the nativity scene and sang songs around the piano every Christmas Eve.  My Father and I took turns performing this Family favorite  upon request.  I sure did enjoy this gorgeous, perfect rendition.  I think the Angels and Heavenly Father enjoyed it too.  Wonderful Girls.  So pleased.  Love from the Colorado Mountains💜 Nobody's Grandma"));

        video2.AddComment(new Comment("DominiqueMills-m9g", "Wooo boy!!! Feeling the Holy Ghost!"));

        // Third Video
        Video video3 = new Video("“Golden” Official Lyric Video | KPop Demon Hunters | Sony Animation", "Sony Pictures Animation", 198);
        // https://www.youtube.com/watch?v=yebNIHKAC4A&list=RDyebNIHKAC4A&start_radio=1

        video3.AddComment(new Comment("minicub-vts", "I’m a 45 year old dad and watched this with my two girls. I cried like the fan dudes in the film. I guess it’s never too late to become a K-pop fan."));

        video3.AddComment(new Comment("Kusanagikaiser999", "I'm serious Sony.........SEQUEL...NOW..........and put this film on THEATERS, it deserve the run."));

        video3.AddComment(new Comment("Espoir_OW", "I'm not Kpop fan but I had to admit, the songs in this movie blows every Disney musical movies in the last couple years out of the water!"));

        video3.AddComment(new Comment("kingphil8150", "Im a grown man who watched this with my two little girls (6 and 7). I cried more they did"));


        // Fourth Video
        Video video4 = new Video("Dance Hits Of The 90s", "Shaltear Music Lounge", 4941);
        // https://www.youtube.com/watch?v=lcTIr5sFJFE&list=RDlcTIr5sFJFE&start_radio=1

        video4.AddComment(new Comment("jekristv", "Love it everyday morning"));

        video4.AddComment(new Comment("Lan226", "NOV. 16, 2025"));

        video4.AddComment(new Comment("JuvelynHogan", "😊"));

        video4.AddComment(new Comment("carlcolar", "NOV.7 2025❤❤❤"));

        video4.AddComment(new Comment("CristinaLopez-e5o", "Sarap mag exercise na gnito ang song 😅 pampagana"));

        // Video List
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayDetails();

            Console.WriteLine("=================================================================================================");
        }
        
    }
}