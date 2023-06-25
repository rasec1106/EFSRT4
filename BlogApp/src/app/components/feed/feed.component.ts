import { Component } from '@angular/core';
import { Comment } from 'src/app/models/comment';
import { Post } from 'src/app/models/post';
import { CommentService } from 'src/app/services/comment.service';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css']
})
export class FeedComponent {

  posts: Post[] = []
  constructor(private postService: PostService, private commentService: CommentService, private userService: UserService) {
    this.getAllPosts()
  }

  getAllPosts(){
    this.postService.getPosts().subscribe(res => {
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

  postComment(post: Post, commentContent: string){
    let comment: Comment = {
      "commentId": 0,
      "userId": JSON.parse(localStorage.getItem('currentUser') as string).userId,
      "content": commentContent,
      "publicationDate": new Date().toISOString(),
      "postId": post.postId as number
    }
    this.commentService.createComment(comment).subscribe(res=>{
      this.getAllPosts()
    })
  }

}
