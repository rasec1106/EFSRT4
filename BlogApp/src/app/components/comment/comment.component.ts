import { Component } from '@angular/core';
import { Comment } from 'src/app/models/comment';
import { User } from 'src/app/models/user';
import { CommentService } from 'src/app/services/comment.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent {
  comments: Comment[] = []
  currentUser: User = JSON.parse(localStorage.getItem('currentUser') as string)
  constructor(private commentService: CommentService){
    this.getMyComments()
  }
  getMyComments(){
    this.commentService.getCommentsByUserId(this.currentUser.userId as number).subscribe(res=>{
      this.comments = res.sort((a:any, b:any) => b.publicationDate?.localeCompare(a.publicationDate as string) as number)
      this.comments.forEach(c=>{
        c.user = this.currentUser
      })
    })
  }
}
