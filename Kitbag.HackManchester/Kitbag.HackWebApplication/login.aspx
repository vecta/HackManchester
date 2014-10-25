<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Login</title>

        <link rel="stylesheet" href="Content/bootstrap.css"/>
        <link rel="stylesheet" href="Content/bootstrap-theme.css"/>
        <link href='http://fonts.googleapis.com/css?family=ABeeZee:400,400italic' rel='stylesheet' type='text/css'>
        <style >
            #googleButton { background: linear-gradient(#d34836, #903125); text-align: left }
            #facebookButton { background: linear-gradient(#4265ad, #3b5998); text-align: left}
            #twitterButton { background: linear-gradient(#55ACEE, #50a2e1); text-align: left }

            body {background-color: #5f5f5f;color: white;background: radial-gradient(at 0 0, #808080, #525252)}
            .c-won-Font { font-family: 'ABeeZee', sans-serif; }
            #LoginBox h1 {font-size: 36pt;margin: 0px;}
            #LoginBox h3 { margin: 4px 0 20px 0; }
            #LoginBox .SocialIcon{ width: 25px;margin-right: 20px;}
            #LoginBox .btn:hover{ color: white;border: 1px solid #808080;}
            #LoginBox{ background-color: #808080;margin: 150px auto;width: 500px;padding: 60px 20px; border-radius: 8px;box-shadow: 5px 5px 20px 0px rgba(0,0,0,0.25);}
        </style>
    </head>
    <body>
        <div id="LoginBox" class="text-center">
            <h1 class="c-won-font"><em>currently</em><strong>working</strong><em>on</em></h1>
            <h3 class="c-won-Font">the social team community</h3>
            <div class="btn-group-vertical">
                <button class="btn btn-lg" id="googleButton"><img src="Content/images/social/google_btn_white.png" class="SocialIcon"/>sign in with Google</button>
                <button class="btn btn-lg" id="facebookButton"><img src="Content/images/social/FB-f-Logo__blue_29.png" class="SocialIcon"/>sign in with Facebook</button>
                <button class="btn btn-lg" id="twitterButton"><img src="Content/images/social/Twitter_logo_white.png" class="SocialIcon"/>sign in with Twitter</button>
            </div>
        </div>
        <footer class="navbar-fixed-bottom"><p class="text-center">&copy; 2014 currentlyworkingon.com</p></footer>
        <script src="Scripts/jquery-1.9.0.js" type="text/javascript"></script>
        <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    </body>
</html>