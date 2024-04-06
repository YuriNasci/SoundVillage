export interface Usuario {
    id:string;
    nome:string;
    email:string;
    senha: string;
    dataNascimento?:Date;
    planoId: string;
    nomeCartao?:string;
    numeroCartao?:string;
    validadeCartao?:Date;
    codigoSeguranca?:string;
}