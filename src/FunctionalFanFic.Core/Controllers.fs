module Controllers
  
  open Bistro.FS.Definitions
  open Bistro.FS.Inference
    
  open Bistro.Controllers.Descriptor
  open Bistro.Controllers.Descriptor.Data

  open Utils


  [<Bind("")>]
  [<RenderWith("Views/home.django")>]
  [<ReflectedDefinition>]
  let home (ctx : ictx) = 
    Stories.find all |> named "stories"

  [<Bind("get /new")>]
  [<RenderWith("Views/new.django")>]
  [<ReflectedDefinition>]
  let newStory (ctx: ictx) = ()

  [<FormData>]
  type storyForm = {
    username:string;
    title:string;
    story:string
    }

  [<Bind("post /new")>]
  [<ReflectedDefinition>]
  let createStory (ctx: ictx) (form:storyForm) = 
    Stories.save {
      User = form.username;
      Title = form.title;
      Story = form.story
    }
    ctx.Transfer("/");

  [<Bind("/read/{title}")>]
  [<RenderWith("Views/read.django")>]
  [<ReflectedDefinition>]
  let readStory (ctx:ictx) title =
    Stories.findByTitle title |> named "story"
    
  [<Bind("get *")>]
  [<ReflectedDefinition>]
  let topics (cts:ictx) =
    Topics.generateTopics 5 |> named "topics"
