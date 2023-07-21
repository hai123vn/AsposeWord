export interface UploadFile {
  file: File,
  fileType: string;
  password?: string;
}

export interface FileOutput {
  fileName: string;
  url: string;
}

export interface NDWord {
  noiDungCanTim: string;
  noiDungThayThe: string;
}

export interface TextAdd {
  textAdd: string;
}
