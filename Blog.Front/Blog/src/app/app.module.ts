import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from './main-page/main-page.component';
import { PostComponent } from './post-page/post/post.component';
import { AuthComponent } from './auth-page/auth/auth.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    PostComponent,
    AuthComponent,
  ],
  imports: [
        // Angular imports
    BrowserModule,
    FormsModule,
    HttpClientModule,
    // Application imports
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
