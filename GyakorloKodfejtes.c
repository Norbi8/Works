#include <stdio.h>

int main() {
    FILE * f  = fopen("be.txt","r");
    FILE * w = fopen("ki.txt","w");
    char kodtype;
    char kod[512];
    char matrix[6][6];
    char k = 'a';
    for (int i = 0; i < 6; ++i) {
        for (int j = 0; j < 6; ++j) {
            matrix[i][j]=k;
            k=k+1;
            if(k>'z'){
                k='0';
            }
        }
    }
    fscanf(f,"%c\n",&kodtype);
    if(kodtype=='K'){
        fscanf(f,"%s",&kod);
        int n= 0;
        while(kod[n]!='\0'){
            n++;
        }
        printf("%c\n%s\n",kodtype,kod);
        printf("%d\n",n);
        fprintf(w,"%d\n",n);
        for (int i = 0; i < n; ++i) {
            int menti = 0;
            int mentj = 0;
            for (int j = 0; j < 6; ++j) {
                for (int l = 0; l < 6; ++l) {
                    if (matrix[j][l] == kod[i]) {
                        menti = j;
                        mentj = l;
                    }
                }
            }
            printf("%d%d\n", menti + 1, mentj + 1);
            fprintf(w, "%d%d\n", menti + 1, mentj + 1);
        }
    } else{
        char szamoki[512];
        char szamokj[512];
        int n = 0;
        while(!feof(f)){
            fscanf(f,"%c%c\n",&szamoki[n],&szamokj[n]);
            n++;
        }

        for (int i = 1; i < n; ++i){
            int kx = szamoki[i]-'0';
            int ky = szamokj[i]-'0';
            for (int j = 0; j < 6; ++j) {
                for (int l = 0; l < 6; ++l) {
                    if(j==kx-1 && ky-1==l){
                        printf("%c",matrix[j][l]);
                        fprintf(w,"%c",matrix[j][l]);
                    }
                }
            }
        }
        fprintf(w,"\n");
    }
    fclose(f);
    fclose(w);
    return 0;
}
