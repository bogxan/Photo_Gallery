import {NgModule} from '@angular/core';
import {SharedModule} from "../shared.module";
import {MainComponent} from "./main.component";
import {RouterModule} from "@angular/router";
import {HomeComponent} from "./home/home.component";
import {PhotosComponent} from "./gallery/photos/photos.component";
import {EditPhotoComponent} from "./gallery/edit-photo/edit-photo.component";
import {CreatePhotoComponent} from "./gallery/create-photo/create-photo.component";
import {PostFeedbackComponent} from "./gallery/post-feedback/post-feedback.component";
import {FeedbacksComponent} from "./gallery/feedbacks/feedbacks.component";
import {PhotosModule} from "./gallery/photos/photos.module";

@NgModule({
  declarations: [
    MainComponent,
    HomeComponent
  ],
  imports: [
    SharedModule,
    PhotosModule,
    RouterModule.forChild([
      {
        path: '',
        component: MainComponent,
        children: [
          {
            path: 'home',
            component: HomeComponent
          },
          {
            path: 'photos',
            component: PhotosComponent,
          },
          {
            path: 'createPhoto',
            component: CreatePhotoComponent,
          },
          {
            path: 'editPhoto/:id',
            component: EditPhotoComponent,
          },
          {
            path: 'postFeedback/:id',
            component: PostFeedbackComponent,
          },
          {
            path: 'feedbacks/:id',
            component: FeedbacksComponent,
          },
        ]
      }
    ])
  ]
})
export class MainModule { }
