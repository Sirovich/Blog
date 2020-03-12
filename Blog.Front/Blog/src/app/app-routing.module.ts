import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { PostComponent } from './post-page/post/post.component';
import { AuthComponent } from './auth-page/auth/auth.component';

const routes: Routes = [
{ path: 'main', component: MainPageComponent },
{ path: 'posts/:postId', component: PostComponent },
{ path: 'auth', component: AuthComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
