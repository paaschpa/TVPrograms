<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
        <strong>ASP.Net MVC + Fluent Nhibernate + StructureMap + AutoMapper + JQuery = Lazy people (like me) need not apply</strong>
        <p></p>
       <div class="hometext">
        Not being very smart means I rely a lot on my good looks.  Unforunately, my good looks (and laziness-is all this typing really needed??) have only allowed me to slack until a recent project.  
        Since I don't want to do any real work and someone told me the above stuff would make my project easier, I needed to find a way to learn it (read: have someone else write most of it for me). 
        So, I figured I'd make this sample project and solicit the help of smart people to do all the real work of making it better.  Then, I just copy their work (thanks high school, you taught me well).  What follows is hopefully some
        best practices (or not completely terrible, I'm not here to judge) for setting up a typical MVC site with FNH. Hopefully it helps other lazy, good-looking people. 
        <p></p>
         <strong>Heres my intellecutal take on what's be used and how.</strong>
         <ul>
            <li>.NET MVC - Good Bye Webforms.  We had fun and you made life easier for a while. But, I need control of my HTML and you write it worse than I do (kudos on your lack of caring, I will always envy that about you).  
         Plus you're constantly posting back everything.  Let it go already...it was only cool in the early 2000's.</li>    
         <li>FNH - I'm lazy and you look like a nerd that likes to do all the work.  Here do all this database stuff, I know you'll like doing it because nerds like that stuff.  Not that I, a good-looking person, would know.
         I'm just assuming, and assuming is what makes me handsome. </li>  
         <li>StructureMap - You are more powerfully than I can possibly imagine.  Use Black Magic to make my controllers work with my interfaces and 'what not'. ('what not' being things I don't understand).</li> 
         <li>AutoMapper - Anything with 'Auto' in its name generally means less work for me.  Plus, it seems like you'll make it easier for me not to work against my Domain Models/Objects (Whatever that means...sometimes it's a good idea to re-say things smart people say). </li>
         <li>Some JQuery - You make something ugly good-looking.  I respect that and obviously can't be seen with the ugly thing.  You're in and will do our best to ignore the ugly thing.</li>
         </ul>
         <p></p>
        <strong>What the Sample does</strong><br />
         I could have used the Nerd Dinner sample, but there is already too much nerdy stuff going on with this. It just made sense to go with something all lazy, good-looking people know-Television.        
         After the datase is populated (should be an SQL script somewhere in here) a user (preferably a good-looking user) can select Programs by Network and click on the program to view some data about the Program. [MORE TO COME]
        </div>
</asp:Content>
