import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FileOutput, UploadFile } from 'src/app/_core/models/upload-file';
import { AsposeWordService } from 'src/app/_core/services/aspose-word.service';
import { FunctionUtility } from 'src/app/_core/utilities';

@Component({
  selector: 'app-form-input',
  templateUrl: './form-input.component.html',
  styleUrls: ['./form-input.component.scss']
})
export class FormInputComponent implements OnInit {
  filename = 'Vui lòng chọn file để upload';
  media: UploadFile = <UploadFile>{
    file: null,
    fileType: 'PDF',
    password: ''
  }

  //#region Transfer 
  fileTypes: string[] = [
    'PDF', 'HTML', 'MD', 'JPEG'
  ]

  //#endregion


  fileOutput: FileOutput[] = [];

  key: string = '';
  constructor(
    private route: ActivatedRoute,
    private wordService: AsposeWordService,
    private functionUtility: FunctionUtility
  ) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.key = this.route.snapshot.paramMap.get('key');
    console.log('this key', this.key);
  }




  onSelectFile(event: any) {
    if (event.target.files && event.target.files[0]) {
      const reader = new FileReader();

      // check file name extension
      const fileNameExtension = event.target.files[0].name.split('.').pop();
      const fileZise = event.target.files[0].size;
      // if (fileNameExtension !== 'jpg' && fileNameExtension !== 'jpeg'
      //   && fileNameExtension !== 'png' && fileNameExtension !== 'JPG'
      //   && fileNameExtension !== 'JPEG' && fileNameExtension !== 'PNG'
      //   && fileNameExtension !== 'mp4' && fileNameExtension !== 'MP4') {
      //   this.alertServices.showWarning(MessageConstant.VALIDATE_IMAGE_EXTENTION);
      //   return;
      // }
      // // Image cannot be larger than 5MB
      // if (fileZise > 5242880 && (fileNameExtension === 'jpg' || fileNameExtension === 'jpeg' ||
      //   fileNameExtension === 'png' || fileNameExtension === 'JPG' ||
      //   fileNameExtension === 'JPEG' || fileNameExtension === 'PNG')
      // ) {
      //   this.alertServices.showWarning(MessageConstant.VALIDATE_IMAGE_NOT_LARGE_5MB);
      //   return;
      // }
      // // Video cannot be larger than 20MB
      // if (fileZise > 20971520 && (fileNameExtension === 'mp4' || fileNameExtension === 'MP4')) {
      //   this.alertServices.showWarning(MessageConstant.VALIDATE_VIDEO_NOT_LARGE_20MB);
      //   return;
      // }

      this.media.file = event.target.files[0];

      reader.readAsDataURL(event.target.files[0]); // read file as data url
      reader.onload = (e) => {
        this.filename = event.target.files[0].name;
        // called once readAsDataURL is completed
        // this.media.fileBase = e.target!.result!.toString();
        // this.media.fileName = event.target.files[0].name;
        // this.media.extention = fileNameExtension;
        // this.media.size = fileZise;
        // this.media.type = event.target.files[0].type;
        // this.returnFile(this.media);
      };
    }
  }

  uploadFile() {
    if (this.media.file != null) {
      if (this.key == "Transfer") {
        this.wordService.convertToPDF(this.media).subscribe({
          next: result => {
            console.log('ressult', result);
            this.fileOutput = result;
          }
        })
      }
      if (this.key == "Security") {
        this.wordService.baoMat(this.media).subscribe({
          next: result => {
            console.log('ressult', result);
            this.fileOutput = [{ ...result }];
          }
        })
      }
    }
  }

  downloadFile(file: FileOutput) {
    this.wordService.downloadFile(file).subscribe({
      next: (ress: Blob) => {
        console.log('ress', ress);
        this.functionUtility.download(ress, file.fileName)
      }
    })
  }

  onChooseFileTypeTransfer(type: string) {
    this.media.fileType = type;
  }
}
