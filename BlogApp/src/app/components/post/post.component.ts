import { Component } from '@angular/core';
import { Comment } from 'src/app/models/comment';
import { Post } from 'src/app/models/post';
import { User } from 'src/app/models/user';
import { CommentService } from 'src/app/services/comment.service';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent {
  posts: Post[] = []
  isCreating: boolean = false
  currentUser: User = JSON.parse(localStorage.getItem('currentUser') as string)
  today: Date = new Date()
  newPost?: Post = {
    postId: 0,
    userId: this.currentUser.userId,
    title: 'Titulo',
    content: 'Contenido',
    imageUrl: '',
    publicationDate: ` ${this.today.toISOString().slice(0,10)}, ${this.today.toISOString().slice(11,19)}`,
    comments: [],
    user: this.currentUser,
  }
  
  constructor(private postService: PostService, private commentService: CommentService, private userService: UserService) {
    this.getMyPosts()
  }

  getMyPosts(){
    let myId = JSON.parse(localStorage.getItem('currentUser') as string).userId
    this.postService.getPostsByUserId(myId).subscribe(res => {
      this.posts = res.sort((a, b) => b.publicationDate?.localeCompare(a.publicationDate as string) as number)
      this.posts.forEach(p => {
        this.userService.getUserById(p.userId as number).subscribe(res=>{
          p.user = res
        })
        this.commentService.getCommentsByPostId(p.postId as number).subscribe(res=>{
          p.comments = res
          p.comments?.forEach(c=>{
            this.userService.getUserById(c.userId as number).subscribe(res=>{
              c.user=res
            })
          })
        })
      })
    })
  }
  clickNewPost(){
    this.isCreating = true
    console.log(this.isCreating)
  }
  cancel(){
    this.isCreating = false
  }
  createPost(post: Post){
    let now = new Date()
    this.newPost= {
      postId: 0,
      userId: this.currentUser.userId,
      title: post.title,
      content: post.content,
      imageUrl: post.imageUrl,
      publicationDate: new Date().toISOString(),
      comments: [],
      user: this.currentUser,
    }
    this.postService.createPost(this.newPost).subscribe(res=>{
      this.getMyPosts()
      this.newPost = {
        postId: 0,
        userId: this.currentUser.userId,
        title: 'Titulo',
        content: 'Contenido',
        imageUrl: '',
        publicationDate: ` ${this.today.toISOString().slice(0,10)} ${this.today.toISOString().slice(11,19)}`,
        comments: [],
        user: this.currentUser,
      }
      this.isCreating= false
    })
  }

  postComment(post: Post, commentContent: string){
    let comment: Comment = {
      "commentId": 0,
      "userId": JSON.parse(localStorage.getItem('currentUser') as string).userId,
      "content": commentContent,
      "publicationDate": new Date().toISOString(),
      "postId": post.postId as number
    }
    this.commentService.createComment(comment).subscribe(res=>{
      this.getMyPosts()
    })
  }

  deletePost(post: Post){
    if (confirm(`Seguro que deseas eliminar este post?`)) {
      this.postService.deletePost(post.postId as number).subscribe(()=>{
        this.getMyPosts()
      })
    }
  }

}
