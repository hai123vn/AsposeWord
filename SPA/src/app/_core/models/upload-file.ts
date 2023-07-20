export interface UploadFile {
    file: File,
    fileType: string;
    password?: string;
}

export interface FileOutput{
    fileName: string;
    url: string;
}
