import { Metadata } from 'next';

export const metadata: Metadata = {
  title: 'Money Keeper',
  description: 'Personal financial management website',
  icons: {
    icon: './favicon.png',
  }
};

export default function RootLayout({ children }: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  );
}