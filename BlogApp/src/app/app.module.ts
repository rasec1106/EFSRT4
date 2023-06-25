import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { SignupComponent } from './components/signup/signup.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { FeedComponent } from './components/feed/feed.component';
import { ProfileComponent } from './components/profile/profile.component';
import { PostComponent } from './components/post/post.component';
import { CommentComponent } from './components/comment/comment.component';
import { UserComponent } from './components/user/user.component';

@NgModule({
  declarations: [
    AppComponent,    
    LoginComponent, 
    NavbarComponent, 
    FooterComponent,
    SignupComponent,
    DashboardComponent,
    SidebarComponent,
    FeedComponent,
    ProfileComponent,
    PostComponent,
    CommentComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: '', component: LoginComponent},
      {path: 'accounts/register', component: SignupComponent},
      {path: 'accounts/login', component: LoginComponent},
      {path: 'dashboard', component: DashboardComponent},
      {path: 'users', component: UserComponent},
      {path: 'profile', component: ProfileComponent},
      {path: 'myposts', component: PostComponent},
      {path: 'mycomments', component: CommentComponent},
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
