import {Component, Input} from "@angular/core";
import {Photo} from "../../../photo.interface";
import {PhotosService} from "../photos/photos.service";

@Component({
  selector: 'photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.scss']
})

export class PhotoComponent{
  @Input() photo: Photo;

  constructor(
    private readonly photosService: PhotosService
  ) {
  }

  onBtnRemoveClick() {
    this.photosService.removePhoto(this.photo.id);
  }
}
