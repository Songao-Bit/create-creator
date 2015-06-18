#include<stdio.h>
#include<stdlib.h>
typedef struct homeworkinfo
{
	char* subject;
	int chapter;
	float problem;
	int difficulty;
} INFO;
INFO* createInfo(char* sub, int c, float p, int d)
{
	INFO* tmp = (INFO*)malloc(sizeof(INFO));
	tmp->subject = sub;
	tmp->chapter = c;
	tmp->problem = p;
	tmp->difficulty = d;
	return tmp;
}//根据信息创建结构体
void writeQues(FILE*fp, float prob, int diff)
{
	fprintf(fp, "   <ques>\n");
	fprintf(fp, "    <quesNo>%.1f</quesNo>\n", prob);
	fprintf(fp, "    <difficulty>%d</difficulty>\n", diff);
	fprintf(fp, "   </ques>\n");
}//写入<ques>......</ques>
void writeChapter(FILE* fp, int chap, float prob, int diff)
{
	fprintf(fp, "  <chapter No=\"%d\">\n", chap);
	writeQues(fp, prob, diff);
	fprintf(fp, "  </chapter>\n");
}//写入<chapter>......</chapter>
void write(FILE* fp, char* sub, int chap, float prob, int diff)
{
	fprintf(fp, " <subject name=\"%s\">\n", sub);
	writeChapter(fp, chap, prob, diff);
	fprintf(fp, " </subject>\n");

}//写入<subject>......</subject>
int main()
{
	FILE*fp = fopen("HOMEWORK1.xml", "w");//创建HOMEWORK1.xml文件并打开
	//fprintf(fp, "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
	//需要写入中文字符时需要将编码改成utf-8
	fprintf(fp, "<homework>\n");
	INFO* homework1 = createInfo("Math", 1, 1.1, 2);
	write(fp, homework1->subject, homework1->chapter, homework1->problem, homework1->difficulty);
	INFO* homework2 = createInfo("C", 5, 7.0, 5);
	write(fp, homework2->subject, homework1->chapter, homework1->problem, homework1->difficulty);
	fprintf(fp, "</homework>\n");
	fclose(fp);//关闭文件
}