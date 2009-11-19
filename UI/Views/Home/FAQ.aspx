<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	FAQ
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
    .answer {margin-left: 10px;}
</style>

    <h2>FAQ</h2>
    Q. How did you get to be so handsome? <br />
        <div class="answer">
        A. It's tough to answer questions like this because I'm so modest and humble.  I prefer to think of myself as a normal 
        guy living in a world where a lot of unlucky people happen to be so ugly.  
        </div>
        <p></p>
    Q. How are you able to write so handsomely? <br />
        <div class="answer">
        A. I type naked. Normally, this would create an pretty nonhandsome image in your mind, but I'm pretty
        sure the image I project via typed words is one of The Thinker crouched over a laptop. <i>(it's like I read your mind - right?)</i>
        </div>
    <p></p>
    Q. Where are the tests? <br />
        <div class="answer">
        A. Tests would assume something I write to be imperfect. I'm the incarnation of perfection.  Everything
        I do is perfect, so why bother testing. Honestly, I was hoping someone would Fork/Branch/Copy/Duplicate (whatever it is Gitters do 
        to plagarize) and write up some tests for this project.  I write bad code and to marry that with bad test code seems abusive 
        <i>(the only I things I abuse are the words handsome, good-looking, and pizza.)</i>
        </div>
</asp:Content>
