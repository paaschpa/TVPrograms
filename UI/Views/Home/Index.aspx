<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
        <strong>ASP.Net MVC + Fluent Nhibernate + StructureMap + AutoMapper + JQuery = Handsome Code</strong>
        <p></p>
       <div class="hometext">
        Not being very smart means I rely a lot on my good looks.  Unforunately, my good looks <i>(and laziness-typing is hard)</i> have only allowed me to slack until a recent project.  
        Since I don't want to do any real work and someone told me the above stuff would make my project easier, I needed to find a way to learn it <i>(read: have someone else write most of it for me)</i>. 
        So, I figured I'd make this sample project and solicit the help of smart people to do all the real work of making it better.  Then, I just copy their work <i>(oh high school, you taught me well)</i>.  What follows is hopefully some
        best practices <i>(or not completely terrible, I'm not here to judge)</i> for setting up a typical MVC site with the above accoutrement <i>(ladies like fancy words sprinkled into sentences)</i>. Hopefully it helps other lazy, good-looking people. 
        <p></p>
         <strong>Heres my intellecutal take on what's be used and how.</strong>
         <ul>
            <li>.NET MVC - Good Bye Webforms.  We had fun and you made life easier for a while. But, I need control of my HTML and you write it worse than I do <i>(kudos on your lack of caring, I will always envy that about you)</i>.  
         Plus, you are constantly posting back everything.  Let it go already...it was only cool in the early 2000's.</li>    
         <li>FNH - I'm lazy and you look like a nerd that likes to do all the work.  Here do all this database stuff, I know you'll like doing it because nerds like that stuff.  Not that I, a good-looking person, would know.
         I'm just assuming, and assuming is what makes me handsome. </li>  
         <li>StructureMap - You are more powerfully than I can possibly imagine.  Use Black Magic to make my controllers work with my interfaces and 'what not'. <i>('what not' being things I don't understand)</i>.</li> 
         <li>AutoMapper - Anything with 'Auto' in title generally means less work for me.  Plus, it seems like it'll make it easier for me not to work against my Domain Models/Objects <i>(whatever that means...sometimes it's a good idea to re-say things smart people say)</i>. </li>
         <li>Some JQuery - You make something ugly good-looking.  I respect that and obviously can't be seen with something ugly.  You're in and we'll do our best to ignore ugly things.</li>
         </ul>
         <p></p>
        <strong>What the Sample does</strong><br />
         I could have used the Nerd Dinner sample, but there is already too much nerdy stuff going on with this. It just made sense to go with something all lazy, good-looking people know-Television.        
         After the database is populated (create tables with DatabaseSchema.sql, populate tables with DatabaseData.sql) a user (preferably a good-looking user) can select Programs by Network and click on the program to view some data about the Program. [MORE TO COME]
        </div>
</asp:Content>
